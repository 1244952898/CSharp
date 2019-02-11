using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CacheDemo
{
    public class MyCacheHelper : ICache
    {
        static MyCacheHelper()
        {
            new Action(() => {
                while (true) {
                    Thread.Sleep(100);
                    foreach (var item in _Dictionary.Where(x => x.Value.Value < DateTime.Now))
                    {
                        _Dictionary.Remove(item.Key);
                    } 
                }
            }).BeginInvoke(null,null);
        }

    private static Dictionary<string, KeyValuePair<object, DateTime>> _Dictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();
        //过期处理
       

        public object this[string key] {
            get {
                if (string.IsNullOrEmpty(key))
                {
                    KeyValuePair<object, DateTime> keyValuePair = _Dictionary[key];
                    if (keyValuePair.Value >= DateTime.Now)
                    {
                       return keyValuePair.Key;
                    }
                    else
                    {
                        _Dictionary.Remove(key);
                    }
                }
                return null;
            }
            set {
                this.Add(key, value);
            }
        }

        public int Count {
            get
            {
                foreach (var item in _Dictionary)
                {
                    if (item.Value.Value<DateTime.Now)
                    {
                        _Dictionary.Remove(item.Key);
                    }
                }
                return _Dictionary.Count;
            }
        }

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
