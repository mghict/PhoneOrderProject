using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace WebSites.Panles.Helper
{
    public class InMemoryCache : ICacheService
    {
        IMemoryCache _memoryCache;
        public static CancellationTokenSource UnKnownToken = new CancellationTokenSource();
        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetOrSet<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(typeof(T).Name, out ret))
            {
                ret = input;
                if (ret != null)
                {
                    if (ret is FluentResult)
                    {
                        var response = ret as FluentResult;

                        if (response.IsFailed)
                        {
                            return ret;
                        }
                    }

                    if (ret is ICollection)
                    {
                        var response = ret as ICollection;

                        if (response == null || response.Count < 1)
                        {
                            return ret;
                        }
                    }

                    var option = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(duration)
                        .SetSlidingExpiration(durationIdel)
                        .SetPriority(priority)
                        .AddExpirationToken(new CancellationChangeToken(token.Token));


                    _memoryCache.Set(typeof(T).Name, ret, option);
                }

            }

            return ret;
        }
        public async Task<T> GetOrSetAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null)
        {
            return await Task.Run(() =>
            {
                T ret = input;

                if (token == null)
                {
                    token = UnKnownToken;
                }

                if (!_memoryCache.TryGetValue(typeof(T).Name, out ret))
                {
                    ret = input;
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count < 1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(typeof(T).Name, ret, option);
                    }

                }

                return ret;
            });

        }
        public T GetOrSet<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<T> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(typeof(T).Name, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = getItemCallback();
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count < 1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(typeof(T).Name, ret, option);
                    }
                }

            }

            return ret;
        }
        public async Task<T> GetOrSetAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<Task<T>> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(typeof(T).Name, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = await getItemCallback();
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count < 1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(typeof(T).Name, ret, option);
                    }
                }

            }

            return ret;
        }
        public T GetOrSet<T, TInput1>(T input, TInput1 paramInput1, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, T> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(typeof(T).Name, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = getItemCallback(paramInput1);
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count <1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(typeof(T).Name, ret, option);
                    }
                }

            }

            return ret;
        }
        public async Task<T> GetOrSetAsync<T, TInput1>(T input, TInput1 paramInput1, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, Task<T>> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(typeof(T).Name, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = await getItemCallback(paramInput1);
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count < 1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(typeof(T).Name, ret, option);
                    }
                }

            }

            return ret;
        }


        public T GetOrSet<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(cacheKey, out ret))
            {
                ret = input;
                if (ret != null)
                {
                    if (ret is FluentResult)
                    {
                        var response = ret as FluentResult;

                        if (response.IsFailed)
                        {
                            return ret;
                        }
                    }

                    if (ret is ICollection)
                    {
                        var response = ret as ICollection;

                        if (response == null || response.Count < 1)
                        {
                            return ret;
                        }
                    }

                    var option = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(duration)
                        .SetSlidingExpiration(durationIdel)
                        .SetPriority(priority)
                        .AddExpirationToken(new CancellationChangeToken(token.Token));


                    _memoryCache.Set(cacheKey, ret, option);
                }

            }

            return ret;
        }
        public async Task<T> GetOrSetAsync<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null)
        {
            //return await Task.Run(() =>
            //{
                T ret = input;

                if (token == null)
                {
                    token = UnKnownToken;
                }

                if (!_memoryCache.TryGetValue(cacheKey, out ret))
                {
                    ret = input;

                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }
                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response==null || response.Count<1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(cacheKey, ret, option);
                    }

                }

                return ret;
            //});

        }
        public T GetOrSet<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<T> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(cacheKey, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = getItemCallback();
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count < 1)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(cacheKey, ret, option);
                    }
                }

            }

            return ret;
        }
        public async Task<T> GetOrSetAsync<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<Task<T>> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(cacheKey, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = await getItemCallback();
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count <= 0)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(cacheKey, ret, option);
                    }
                }

            }

            return ret;
        }
        public T GetOrSet<T, TInput1>(T input, TInput1 paramInput1, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, T> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(cacheKey, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = getItemCallback(paramInput1);
                    if (ret != null)
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var response = ret as ICollection;

                            if (response == null || response.Count <= 0)
                            {
                                return ret;
                            }
                        }

                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(cacheKey, ret, option);
                    }
                }

            }

            return ret;
        }
        public async Task<T> GetOrSetAsync<T, TInput1>(T input, TInput1 paramInput1, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low, CancellationTokenSource token = null, Func<TInput1, Task<T>> getItemCallback = null)
        {
            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (!_memoryCache.TryGetValue(cacheKey, out ret))
            {
                if (getItemCallback != null)
                {
                    ret = await getItemCallback(paramInput1);
                    if (ret != null )
                    {
                        if (ret is FluentResult)
                        {
                            var response = ret as FluentResult;

                            if (response.IsFailed)
                            {
                                return ret;
                            }
                        }

                        if (ret is ICollection)
                        {
                            var iEnum = ret as ICollection;
                            if(iEnum==null || iEnum.Count<1)
                            {
                                return ret;
                            }
                        }


                        var option = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(duration)
                            .SetSlidingExpiration(durationIdel)
                            .SetPriority(priority)
                            .AddExpirationToken(new CancellationChangeToken(token.Token));


                        _memoryCache.Set(cacheKey, ret, option);
                    }
                    
                }

            }

            return ret;
        }



        public void ClearCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
        public async Task ClearCacheAsync(string cacheKey)
        {
            await Task.Run(() =>
            {
                _memoryCache.Remove(cacheKey);
            });

            return;

        }

        public void ClearCache<T>(T input)
        {
            _memoryCache.Remove(typeof(T).Name);
        }
        public async Task ClearCacheAsync<T>(T input)
        {
            await Task.Run(() => {
                _memoryCache.Remove(typeof(T).Name);
            });
            
        }

        public T ClearToken<T>(T input) where T : CancellationTokenSource
        {
            input.Cancel();
            input = (new CancellationTokenSource()) as T;

            return input;
        }
        public async Task<T> ClearTokenAsync<T>(T input) where T : CancellationTokenSource
        {
            return await Task.Run(() =>
            {
                input.Cancel();
                input = (new CancellationTokenSource()) as T;

                return input;
            });
            
        }

        public T RemoveAndSet<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low,
            CancellationTokenSource token = null)
        {

            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (ret != null)
            {

                var option = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(duration)
                    .SetSlidingExpiration(durationIdel)
                    .SetPriority(priority)
                    .AddExpirationToken(new CancellationChangeToken(token.Token));


                _memoryCache.Remove(typeof(T).Name);

                _memoryCache.Set(typeof(T).Name, ret, option);
            }


            return ret;
        }
        public async Task< T> RemoveAndSetAsync<T>(T input, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low,
            CancellationTokenSource token = null)
        {
            return await Task.Run(() =>
            {
                T ret = input;

                if (token == null)
                {
                    token = UnKnownToken;
                }

                if (ret != null)
                {

                    var option = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(duration)
                        .SetSlidingExpiration(durationIdel)
                        .SetPriority(priority)
                        .AddExpirationToken(new CancellationChangeToken(token.Token));


                    _memoryCache.Remove(typeof(T).Name);

                    _memoryCache.Set(typeof(T).Name, ret, option);
                }


                return ret;
            });
            
        }

        public T RemoveAndSet<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low,
            CancellationTokenSource token = null)
        {

            T ret = input;

            if (token == null)
            {
                token = UnKnownToken;
            }

            if (ret != null)
            {

                var option = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(duration)
                    .SetSlidingExpiration(durationIdel)
                    .SetPriority(priority)
                    .AddExpirationToken(new CancellationChangeToken(token.Token));


                _memoryCache.Remove(cacheKey);

                _memoryCache.Set(cacheKey, ret, option);
            }


            return ret;
        }
        public async Task<T> RemoveAndSetAsync<T>(T input, string cacheKey, TimeSpan duration, TimeSpan durationIdel, CacheItemPriority priority = CacheItemPriority.Low,
            CancellationTokenSource token = null)
        {
            return await Task.Run(() =>
            {
                T ret = input;

                if (token == null)
                {
                    token = UnKnownToken;
                }

                if (ret != null)
                {

                    var option = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(duration)
                        .SetSlidingExpiration(durationIdel)
                        .SetPriority(priority)
                        .AddExpirationToken(new CancellationChangeToken(token.Token));


                    _memoryCache.Remove(cacheKey);

                    _memoryCache.Set(cacheKey, ret, option);
                }


                return ret;
            });
        }

        public T Get<T>()
        {
            T ret;

            _memoryCache.TryGetValue(typeof(T).Name, out ret);

            return ret;
        }

        public T Get<T>(string key)
        {
            T ret;

            _memoryCache.TryGetValue(key, out ret);

            return ret;
        }

        public async Task<T> GetAsync<T>()
        {
            
            return await Task.Run(() =>
            {
                T ret;

                _memoryCache.TryGetValue(typeof(T).Name, out ret);

                return ret;
            });
            

            
        }

        public async Task<T> GetAsync<T>(string key)
        {
            

            return await Task.Run(() =>
            {
                T ret;
                _memoryCache.TryGetValue(key, out ret);
                return  ret;
            });
            

            
        }

    }
}