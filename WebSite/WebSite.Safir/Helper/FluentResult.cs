using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebSite.Safir.Helper
{
    public class Messages
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class FluentResult:object
    {
        public FluentResult():base()
        {
            Errors = new List<Messages>();
            Successes = new List<Messages>();
            IsSuccess = false;
            IsFailed = true;
        }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("isFailed")]
        public bool IsFailed { get; set; }

        [JsonProperty("errors")]
        public List<Messages>? Errors { get; set; }

        [JsonProperty("successes")]
        public List<Messages>? Successes { get; set;}

        public string GetErrors()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(var err in Errors)
            {
                sb.Append(err.Message + "\n");
            }

            return sb.ToString();
        }

        public string GetSuccesses()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var suc in Successes)
            {
                sb.Append(suc.Message + "\n");
            }

            return sb.ToString();
        }
    }

    public class FluentResult<T> : FluentResult
    {
        public T Value { get; set; }

    }

    public static class ExtensionFluent
    {
        public static FluentResult<T> WithValue<T>(this FluentResult<T> input,T value)
        {
            input.Value = value;
            return input;
        }
        public static FluentResult WithError(this FluentResult input,string error)
        {
            input.Errors.Add(new Messages(){Message = error});
            input.IsFailed = true;
            input.IsSuccess = false;
            return input;
        }
        public static FluentResult WithSuccess(this FluentResult input, string success)
        {
            input.Successes.Add(new Messages() { Message = success });
            if (input.Errors.Count == 0)
            {
                input.IsFailed = false;
                input.IsSuccess = true;
            }

            return input;
        }
        public static FluentResult<T> WithError<T>(this FluentResult<T> input, string error)
        {
            input.Errors.Add(new Messages() { Message = error });
            input.IsFailed = true;
            input.IsSuccess = false;
            return input;
        }
        public static FluentResult<T> WithSuccess<T>(this FluentResult<T> input, string success)
        {
            input.Successes.Add(new Messages() { Message = success });
            if (input.Errors.Count==0)
            {
                input.IsFailed = false;
                input.IsSuccess = true;
            }
            
            return input;
        }

    }
}
