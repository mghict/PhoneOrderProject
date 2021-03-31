using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LogManager.Api
{
    public class EventConsumer :
        IConsumer<LogFromat>
    {
        ILogger<EventConsumer> _logger;

        public EventConsumer(ILogger<EventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<LogFromat> context)
        {
            if (context.Message.MessageType.ToUpper().Equals("LOG"))
            {
                string valueMessage = $"{context.Message.MessageBody}";
                switch (context.Message.LogLevel)
                {
                    case LogLevel.Information:
                        _logger.LogInformation(valueMessage);
                        break;
                    case LogLevel.Warning:
                        _logger.LogWarning(valueMessage);
                        break;
                    case LogLevel.Error:
                        _logger.LogError(valueMessage);
                        break;
                    case LogLevel.Critical:
                        _logger.LogCritical(valueMessage);
                        break;
                    case LogLevel.Trace:
                        _logger.LogTrace(valueMessage);
                        break;
                    case LogLevel.Debug:
                        _logger.LogDebug(valueMessage);
                        break;

                }
            }
            
        }
    }
}
