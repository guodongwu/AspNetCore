using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace LearnCore.Untity
{
    public class RedisCacheHelper : ICacheHelper
    {
        private IDatabase _cache;
        private ConnectionMultiplexer _connection;
        private readonly string _instanceName;
        public RedisCacheHelper()
        {
            RedisCacheOptions options = new RedisCacheOptions();
            options.Configuration = "127.0.0.1:6379";
            options.InstanceName = "Redis_Session";
            int database = 0;
            _connection = ConnectionMultiplexer.Connect(options.Configuration);
            _cache = _connection.GetDatabase(database);
            _instanceName = options.InstanceName;
        }
        private string GetKeyForRedis(string key)
        {
            return _instanceName + key;
        }
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Exist(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));


            return _cache.KeyExists(GetKeyForRedis(key));
        }

        public T GetCache<T>(string key) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));


            var value = _cache.StringGet(GetKeyForRedis(key));
            if (!value.HasValue)
                return default(T);


            return JsonConvert.DeserializeObject<T>(value);
        }

        public void RemoveCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));


            _cache.KeyDelete(GetKeyForRedis(key));
        }

        public void SetCache(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));


            if (Exist(GetKeyForRedis(key)))
                RemoveCache(GetKeyForRedis(key));


            _cache.StringSet(GetKeyForRedis(key), JsonConvert.SerializeObject(value));
        }

        public void SetCache(string key, object value, DateTimeOffset expiressAbsoulte)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (Exist(GetKeyForRedis(key)))
                RemoveCache(GetKeyForRedis(key));
            _cache.StringSet(GetKeyForRedis(key), JsonConvert.SerializeObject(value), expiressAbsoulte - DateTime.Now);
        }
    }


}
