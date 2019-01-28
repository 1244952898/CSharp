using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    public class MyCacheHelper : ICache
    {
        private static Dictionary<string, KeyValuePair<object,DateTime>> _Dictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();

        public object this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public void Add(string key, object data, int cacheTime = 30)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            KeyValuePair<object, DateTime> keyValuePair = new KeyValuePair<object, DateTime>(data, DateTime.Now.AddMinutes(cacheTime));

            _Dictionary.Add(key, keyValuePair);

        }

        public bool Contains(string key)
        {
            if (_Dictionary.ContainsKey(key))
            {
                KeyValuePair<object, DateTime> keyValuePair = _Dictionary[key];
                if (keyValuePair.Value >= DateTime.Now) {
                    return true;
                }
                else
                {
                    _Dictionary.Remove(key);
                }
            }
            return false;
        }

        public T Get<T>(string key)
        {
            if (_Dictionary.ContainsKey(key))
            {
                KeyValuePair<object, DateTime> keyValuePair = _Dictionary[key];
                if (keyValuePair.Value<DateTime.Now)
                {
                    _Dictionary.Remove(key);
                    return default(T);
                }
                return (T)keyValuePair.Key;
            }
            else
                return default(T);
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
