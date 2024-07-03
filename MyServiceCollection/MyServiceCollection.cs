using System.Collections;

namespace MyServiceCollection
{
    public class MyServiceCollection : IMyServiceCollection
    {
        #region Fields

        private readonly List<MyServiceDescriptor> _descriptors = [];
        private bool _isReadOnly;
        public bool IsReadOnly => _isReadOnly;
        public int Count => _descriptors.Count;
        public MyServiceDescriptor this[int index]
        {
            get
            {
                return _descriptors[index];
            }
            set
            {
                CheckReadOnly();
                _descriptors[index] = value;
            }
        }

        #endregion

        #region Public Methods

        public bool Contains(MyServiceDescriptor item)
        {
            return _descriptors.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(MyServiceDescriptor[] array, int arrayIndex)
        {
            _descriptors.CopyTo(array, arrayIndex);
        }

        public bool Remove(MyServiceDescriptor item)
        {
            CheckReadOnly();
            return _descriptors.Remove(item);
        }

        public IEnumerator<MyServiceDescriptor> GetEnumerator()
        {
            return _descriptors.GetEnumerator();
        }

        void ICollection<MyServiceDescriptor>.Add(MyServiceDescriptor item)
        {
            CheckReadOnly();
            _descriptors.Add(item);
        }

        public void Clear()
        {
            CheckReadOnly();
            _descriptors.Clear();
        }

        public int IndexOf(MyServiceDescriptor item)
        {
            return _descriptors.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, MyServiceDescriptor item)
        {
            CheckReadOnly();
            _descriptors.Insert(index, item);
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            CheckReadOnly();
            _descriptors.RemoveAt(index);
        }
        #endregion

        #region Private Methods

        private void CheckReadOnly()
        {
            if (_isReadOnly)
            {
                throw new InvalidOperationException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
}
