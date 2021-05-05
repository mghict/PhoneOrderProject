using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehsamFreamwork.Logger;
using System.IO;
using Microsoft.IO;

namespace BehsamFramework.Util.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly InternalLogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public LoggingMiddleware(RequestDelegate next, InternalLogger logger)
        {
            _next = next;
            _logger = logger;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }


        public async Task Invoke(HttpContext context)
        {
            await RequestLogAsync(context);
            await LogResponseAsync(context);
            //await _next(context);
        }

        //-------------------------------------------------------------
        // Request Logger
        //-------------------------------------------------------------
        private async Task RequestLogAsync(HttpContext context)
        {
            LogMessage _LogMessage = await returnLogMessage(context);
            await SendForLog(_LogMessage, LogLevel.Information);
        }

        //-------------------------------------------------------------
        // Response Logger
        //-------------------------------------------------------------
        private async Task LogResponseAsync(HttpContext context)
        {

            var isSuccess = context.Response.StatusCode == 200 ? true : false;

            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            

            if(!string.IsNullOrEmpty(text))
            {
                try
                {
                    var item = text.FromJsonString<FluentResults.Result>();
                    if(item!=null)
                    {
                        var body = new
                        {
                            IsSuccess = item.IsSuccess,
                            Message = item.Successes.ToList().Select(p => p.Message).ToList().ToString(),
                            Errors = item.Errors.ToList().Select(p => p.Message).ToList().ToString()
                        };

                        text = body.ToJsonString();
                    }

                }
                catch(Exception ex)
                {
                    text = text.Trim().Replace("=", ":");

                    var bodyText = new
                    {
                        IsSuccess = isSuccess,
                        Message = isSuccess ? text : "",
                        Errors = isSuccess ? "" : text
                    };

                    text = bodyText.ToJsonString();
                }
                
            }

            LogMessage logMessage = await returnLogMessage(context);
            logMessage.Body = text;
            logMessage.Status = context.Response.StatusCode.ToString("000");

            if(isSuccess)
            {
                await SendForLog(logMessage, LogLevel.Information);
            }
            else
            {
                await SendForLog(logMessage, LogLevel.Error);
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }

        //-------------------------------------------------------------
        // Logger To RabbitMQ
        //-------------------------------------------------------------
        private async Task SendForLog(LogMessage logMessage,LogLevel logLevel)
        {
            var log = new InternalLog()
            {
                LogLevel = logLevel,
                LogMessage = logMessage.ToSerialize()
            };

            await _logger.SendToQueue(log);

            return;
        }

        //-------------------------------------------------------------
        // Method Helper
        //-------------------------------------------------------------

        private async Task<LogMessage> returnLogMessage(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            string contextBody = "";

            if (context.Request.Method.ToUpper() == "POST")
            {
                contextBody = ReadStreamInChunks(requestStream).Trim();
                context.Request.Body.Position = 0;

                if (!string.IsNullOrEmpty(contextBody))
                {
                    contextBody = contextBody.ToJsonString();
                }
            }
            else if (context.Request.Method.ToUpper() == "GET")
            {
                contextBody = context.Request.QueryString.Value.Replace("?", "").Replace("=", ":").Trim();
                if (!string.IsNullOrEmpty(contextBody))
                {
                    contextBody = contextBody.ToJsonString();
                }
            }

            string[] pathArray = context.Request.Path.Value.Split("/");
            int pathArrayLength = pathArray.Length;

            string Id = context.Request.Headers["Id"].ToString();
            Id = string.IsNullOrEmpty(Id) ? "0" : Id;

            LogMessage _LogMessage = new LogMessage()
            {
                ControllrName = pathArrayLength >= 2 ? pathArray[pathArrayLength - 2] : "UnKnown",
                ActionName = pathArrayLength >= 2 ? pathArray[pathArrayLength - 1] : "UnKnown",
                MethodName = context.Request.Method,
                IP = context.Connection.RemoteIpAddress.ToString(),
                UserId = Convert.ToInt32(Id),
                UserName = context.Request.Headers["Name"].ToString(),
                CreateDate = System.DateTime.Now,
                Status = "000",
                Body = contextBody,
            };

            return _LogMessage;
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }
    }
}
