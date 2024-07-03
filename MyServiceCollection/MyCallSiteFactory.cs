using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection
{
    public class MyCallSiteFactory
    {
        private struct ServiceDescriptorCacheItem
        {
            [DisallowNull]
            private MyServiceDescriptor? _item;

            [DisallowNull]
            private List<MyServiceDescriptor>? _items;

            public MyServiceDescriptor Last
            {
                get
                {
                    if (_items != null && _items.Count > 0)
                    {
                        return _items[_items.Count - 1];
                    }

                    Debug.Assert(_item != null);
                    return _item;
                }
            }

            public int Count
            {
                get
                {
                    if (_item == null)
                    {
                        Debug.Assert(_items == null);
                        return 0;
                    }

                    return 1 + (_items?.Count ?? 0);
                }
            }

            public MyServiceDescriptor this[int index]
            {
                get
                {
                    if (index >= Count)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }

                    if (index == 0)
                    {
                        return _item!;
                    }

                    return _items![index - 1];
                }
            }

            public int GetSlot(MyServiceDescriptor descriptor)
            {
                if (descriptor == _item)
                {
                    return Count - 1;
                }

                if (_items != null)
                {
                    int index = _items.IndexOf(descriptor);
                    if (index != -1)
                    {
                        return _items.Count - (index + 1);
                    }
                }

                throw new InvalidOperationException();
            }

            public ServiceDescriptorCacheItem Add(MyServiceDescriptor descriptor)
            {
                var newCacheItem = default(ServiceDescriptorCacheItem);
                if (_item == null)
                {
                    Debug.Assert(_items == null);
                    newCacheItem._item = descriptor;
                }
                else
                {
                    newCacheItem._item = _item;
                    newCacheItem._items = _items ?? new List<MyServiceDescriptor>();
                    newCacheItem._items.Add(descriptor);
                }
                return newCacheItem;
            }
        }
    }
}
