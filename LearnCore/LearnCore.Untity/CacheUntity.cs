using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCore.Untity
{

    public class CacheUntity
    {
        private static ICacheHelper _cacheHelper = new RedisCacheHelper();

        private static bool isInit = false;

        public static void Init(ICacheHelper cacheHelper)
        {
            if (isInit)
            {
                return;
            }
            _cacheHelper.Dispose();
            _cacheHelper = cacheHelper;
            isInit = true;
        }
        public static bool Exist(string key)
        {
            return _cacheHelper.Exist(key);
        }


        public static T GetCache<T>(string key) where T : class
        {
            return _cacheHelper.GetCache<T>(key);
        }


        public static void SetCache(string key, object value)
        {
            _cacheHelper.SetCache(key, value);
        }


        public static void SetCache(string key, object value, DateTimeOffset expiressAbsoulte)
        {
            _cacheHelper.SetCache(key, value, expiressAbsoulte);
        }


        public static void RemoveCache(string key)
        {
            _cacheHelper.RemoveCache(key);
        }
    }
}
