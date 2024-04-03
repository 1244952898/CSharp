using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    /// <summary>
    /// 生成的类即实现了IEnumerable接口也实现了IEnumerator接口
    /// 说明它既包含了GetEnumerator()方法，也包含MoveNext()方法和Current属性
    /// </summary>
    public sealed class YeildTheory : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
    {





        public object Current => throw new NotImplementedException();

        int IEnumerator<int>.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
