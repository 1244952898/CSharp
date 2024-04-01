using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    public class YeildTheory : IEnumerator<int>, IEnumerator, IDisposable
    {
        private int _state;
        private int _current;
        public Foo foo;
        private List<int>.Enumerator enumerator;
        private int item;

        int IEnumerator<int>.Current
        {
            get { return _current; }
        }
        object IEnumerator.Current
        {
            get { return _current; }
        }

        public YeildTheory(int _state)
        {
            this._state = _state;
        }

        private bool MoveNext()
        {
            try
            {
                int num = _state;
                if (num != 0)
                {
                    if (num != 1)
                    {
                        return false;
                    }
                    _state = -3;
                }
                else
                {
                    _state = -1;
                    enumerator = foo.Ints.GetEnumerator();
                    _state = -3;
                }

                //因为上面的扩展方法里使用的是foreach遍历方式
                //这里也被编译成了实际生产方式
                if (enumerator.MoveNext())
                {
                    item = enumerator.Current;
                    _current = item;
                    _state = 1;
                    return true;
                }

                enumerator = default;
                return false;
            }
            catch (Exception)
            {
                ((IDisposable)this).Dispose();
                throw;
            }
        }

        bool IEnumerator.MoveNext()
        {
            return this.MoveNext();
        }

        void IEnumerator.Reset()
        {
        }

        public void Dispose()
        {
        }
    }

    public class Foo
    {
        public List<int> Ints { get; set; } = new List<int>();
    }
}
