using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.MyListEnumerator
{
    public class MyList<T> : IEnumerable<T>, IEnumerable
    {
        private T[] _items;
        public int _size { get; set; }
        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _items[index];
            }
            set
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _items[index] = value;
                //_version++;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        public struct MyEnumerator : IEnumerator<T>, IEnumerator
        {
            #region Property
            private int index;
            private T current;
            private MyList<T> list;

            public T Current
            {
                get
                {
                    return current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == list._size + 1)
                    {
                        throw new InvalidOperationException();
                    }

                    return Current;
                }
            }
            #endregion

            public MyEnumerator(MyList<T> list)
            {
                index = 0;
                current = default;
                this.list = list;
            }

            #region Method
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (index < list._size)
                {
                    current = list[index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                index = list._size + 1;
                current = default;
                return false;
            }

            public void Reset()
            {
                index = 0;
                current = default;
            }
            #endregion

        }
    }


}
