using Microsoft.Extensions.Caching.Memory;

namespace ShortestLink.Api.Services
{
    public class CacheService : ICacheService
    {
        private IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string GetCachedUrl(string key)
        {
            return _cache.Get<string>(key);
        }

        public void SetCachedUrl(string key, string value)
        {
            _cache.Set(key, value);
        }
    }
}