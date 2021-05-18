using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebSite.JourChin.Helper
{
    public interface ICachedMemoryService
    {
        Task SetCachedAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, string cachedKey = "");
        Task<T> GetCachedAsync<T>(string cachedKey = "");
        Task ClearCacheAsync<T>(T input);
        Task ClearCacheAsync(string cacheKey);
        Task ClearTokenAsync<T>(T input) where T : CancellationTokenSource;
    }

    public class CachedMemoryService : ICachedMemoryService
    {
        private readonly IMemoryCache _memoryCache;
        private static CancellationTokenSource UnKnownToken = new CancellationTokenSource();

        public CachedMemoryService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task SetCachedAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null,string cachedKey="")
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if(string.IsNullOrEmpty(cachedKey))
            {
                cachedKey = typeof(T).Name;
            }

            bool isExists = _memoryCache.TryGetValue(cachedKey, out ret);

            if (isExists)
            {
                await ClearCacheAsync(input);
            }

            var option = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(duration)
                        .SetSlidingExpiration(durationIdel)
                        .SetPriority(priority)
                        .AddExpirationToken(new CancellationChangeToken(token.Token));


            _memoryCache.Set(typeof(T).Name, ret, option);
        }
        public async Task<T> GetCachedAsync<T>(string cachedKey = "")
        {

            return await Task.Run(() =>
            {
                T ret;

                if (string.IsNullOrEmpty(cachedKey))
                {
                    cachedKey = typeof(T).Name;
                }

                _memoryCache.TryGetValue(cachedKey, out ret);

                return ret;
            });
 
        }

        public async Task ClearCacheAsync<T>(T input)
        {
            await Task.Run(() =>
            {
                _memoryCache.Remove(typeof(T).Name);
            });

        }
        public async Task ClearCacheAsync(string cacheKey)
        {
            await Task.Run(() =>
            {
                _memoryCache.Remove(cacheKey);
            });

            return;

        }
        public async Task ClearTokenAsync<T>(T input) where T : CancellationTokenSource
        {
            await Task.Run(() =>
            {
                input.Cancel();
            });

        }
    }
}
