using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCore.Untity
{
    public interface ICacheHelper
    {
        bool Exist(string key);

        T GetCache<T>(string key) where T : class;

        void SetCache(string key, object value);

        void SetCache(string key, object value, DateTimeOffset expiressAbsoulte);

        void RemoveCache(string key);
        void Dispose();
    }
}
