using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threadlianxi
{
    internal class ExceptionDemo
    {
        public void M()
        {
            try
            {
                Thread t0 = new Thread(CatchException);
                t0.Start();
                t0.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"get NotCatchException {ex.Message}");
            }

            try
            {
                Thread t1 = new Thread(NotCatchException);
                t1.Start();
                t1.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"get NotCatchException {ex.Message}");
            }
          
        }
        public void CatchException()
        {
            try
            {
                throw new Exception("CatchException");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"get CatchException inside");
            }
        }
        public void NotCatchException() 
        {
            throw new Exception("NotCatchException");
        }
    }
}
