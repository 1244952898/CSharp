using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    //生成的类即实现了IEnumerable接口也实现了IEnumerator接口
    //说明它既包含了GetEnumerator()方法，也包含MoveNext()方法和Current属性
    public class YieldDemo : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
    {
        private int _state_1;
        //当前迭代结果
        private int _current_2;
        private int _initialThreadId_3;
        public Object _this_4;
        private int _i_5;

        //当前迭代到的结果
        int IEnumerator<int>.Current
        {
            get { return _current_2; }
        }

        //当前迭代到的结果
        object IEnumerator.Current
        {
            get { return _current_2; }
        }

        //构造函数包含状态字段，变向说明靠状态机去实现核心流程流转
        public YieldDemo(int state)
        {
            this._state_1 = state;
            _initialThreadId_3 = Environment.CurrentManagedThreadId;
        }

        //核心方法MoveNext
        public bool MoveNext()
        {
            int num = _state_1;
            if (num != 0)
            {
                if (num != 1)
                {
                    return false;
                }
                //控制状态
                _state_1 = -1;
                //自增 也就是代码里循环的i++
                _i_5++;
            }
            else
            {
                _state_1 = -1;
                _i_5 = 0;
            }

            // 循环终止条件 上面循环里的i < 5
            if (_i_5 < 5)
            {
                Console.WriteLine("内部遍历了:{0}", _i_5);
                //把当前迭代结果赋值给Current属性
                _current_2 = _i_5;
                _state_1 = 1;
                //说明可以继续迭代
                return true;
            }
            //迭代结束
            return false;
        }

        //IEnumerator的MoveNext方法
        bool IEnumerator.MoveNext()
        {
            return this.MoveNext();
        }

        //IEnumerable的IEnumerable方法
        public IEnumerator<int> GetEnumerator()
        {
            //实例化<GetInts>d__1实例
            YieldDemo yieldDemo;
            if (_state_1 == -2 && _initialThreadId_3 == Environment.CurrentManagedThreadId)
            {
                _state_1 = 0;
                yieldDemo = this;
            }
            else
            {
                //给状态机初始化
                yieldDemo = new YieldDemo(0);
                yieldDemo._this_4 = _this_4;
            }
            //因为<GetInts>d__1实现了IEnumerator接口所以可以直接返回
            return yieldDemo;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //因为<GetInts>d__1实现了IEnumerator接口所以可以直接转换
            return ((IEnumerable<int>)this).GetEnumerator();
        }

        void IEnumerator.Reset()
        {
        }

        void IDisposable.Dispose()
        {
        }

    }
}
