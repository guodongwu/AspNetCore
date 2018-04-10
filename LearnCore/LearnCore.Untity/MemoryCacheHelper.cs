using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;


namespace LearnCore.Untity
{
    public class MemoryCacheHelper : ICacheHelper
    {
        private IMemoryCache _cache;

        public MemoryCacheHelper()
        {
            this._cache = new MemoryCache(new MemoryCacheOptions());
        }

        public void Dispose()
        {
            if (_cache != null)
                _cache.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Exist(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));


            object v = null;
            return this._cache.TryGetValue<object>(key, out v);
        }

        public T GetCache<T>(string key) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));


            T v = null;
            this._cache.TryGetValue<T>(key, out v);


            return v;
        }

        public void RemoveCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));


            this._cache.Remove(key);
        }

        public void SetCache(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));


            object v = null;
            if (this._cache.TryGetValue(key, out v))
                this._cache.Remove(key);
            this._cache.Set<object>(key, value);
        }

        public void SetCache(string key, object value, DateTimeOffset expiressAbsoulte)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));


            object v = null;
            if (this._cache.TryGetValue(key, out v))
                this._cache.Remove(key);


            this._cache.Set<object>(key, value, expiressAbsoulte);
        }
    }
}
