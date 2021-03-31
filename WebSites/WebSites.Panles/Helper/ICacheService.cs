using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace WebSites.Panles.Helper
{
    public interface ICacheService
    {
        T GetOrSet<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null);
        Task<T> GetOrSetAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null);
        T GetOrSet<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<T> getItemCallback = null) ;
        Task<T> GetOrSetAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<Task<T>> getItemCallback = null);
        T GetOrSet<T, TInput1>(T input, TInput1 paramInput1, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, T> getItemCallback = null);
        Task<T> GetOrSetAsync<T, TInput1>(T input, TInput1 paramInput1, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, Task<T>> getItemCallback = null);

        T GetOrSet<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null);
        Task<T> GetOrSetAsync<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null);
        T GetOrSet<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<T> getItemCallback = null);
        Task<T> GetOrSetAsync<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<Task<T>> getItemCallback = null);
        T GetOrSet<T,TInput1>(T input, TInput1 paramInput1, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1,T> getItemCallback = null);
        Task<T> GetOrSetAsync<T, TInput1>(T input, TInput1 paramInput1, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, Task<T>> getItemCallback = null);



        void ClearCache(string cacheKey);
        Task ClearCacheAsync(string cacheKey);
        void ClearCache<T>(T input);
        Task ClearCacheAsync<T>(T input);

        T ClearToken<T>(T input) where T : CancellationTokenSource;
        Task<T> ClearTokenAsync<T>(T input) where T : CancellationTokenSource;

        T RemoveAndSet<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null);
        Task<T> RemoveAndSetAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low,
            CancellationTokenSource token = null);

        T RemoveAndSet<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null);
        Task<T> RemoveAndSetAsync<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low,
            CancellationTokenSource token = null);


        T Get<T>();
        T Get<T>(string key);
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(string key);

    }
}