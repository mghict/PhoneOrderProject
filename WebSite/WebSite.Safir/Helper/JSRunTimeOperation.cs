using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace WebSite.Safir.Helper
{
    public static class JSRunTimeOperation
    {
        //public static ValueTask<object> SetItems(this IJSRuntime js,string key,string value)
        //{
        //    return js.InvokeAsync<object>("localStorage.setItem",key,value);
        //}
        //public static ValueTask<string> GetItems(this IJSRuntime js, string key)
        //{
        //    return js.InvokeAsync<string>("localStorage.getItem", key);
        //}

        //public static ValueTask<object> RemoveItems(this IJSRuntime js, string key)
        //{
        //    return js.InvokeAsync<object>("localStorage.removeItem", key);
        //}


        //**********************************************************************

        public static async Task<T> GetItems<T>(this IJSRuntime js,string key)
        {
            var json = await js.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public static async Task SetItems<T>(this IJSRuntime js, string key, T value)
        {
            await js.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public static async Task RemoveItems(this IJSRuntime js, string key)
        {
            await js.InvokeVoidAsync("localStorage.removeItem", key);
        }

    }
}
