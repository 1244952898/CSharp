using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinLockDemo
{
    internal struct SimpleSpinLock
    {
        private Int32 m_ResourceInUsed = 0;//0=false 1=true

        public SimpleSpinLock()
        {
        }

        public void Enter()
        {
            while(true)
            {
                if (Interlocked.Exchange(ref m_ResourceInUsed,1)==0)
                {
                    return;
                }
                Console.WriteLine("添加黑科技");
            }
        }

        public void Leave()
        {
            Volatile.Write(ref m_ResourceInUsed, 0);
        }
    }
}
