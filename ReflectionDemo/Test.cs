using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class TestParent
    {
    }
    public class Test
    {
        public Test(){ }
        public Test(int i){ }
        public Test(string i){ }
        public Test(TestParent p){ }
        protected Test(long p){ }

        private Test(double d)
        {
        }
        public void GetInt()
        {
        }
        public int GetInt(int i)
        {
            return i;
        }
        private int GetIntPrivate(int i)
        {
            return i;
        }
        protected int GetIntprotected(string i)
        {
            return 0;
        }
    }
}
