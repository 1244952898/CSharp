using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    public class ParallelAggregateException
    {
        public static void Test() {

            Random random = new Random();
            byte[] data = new byte[5000];
            random.NextBytes(data);

            try
            {
                ProcessDataInParallel(data);
            }
            catch (AggregateException ae)
            {
                var ignoredExceptions = new List<Exception>();

                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentException)
                        Console.WriteLine(ex.Message);
                    else
                        ignoredExceptions.Add(ex);
                }
                if (ignoredExceptions.Count > 0)
                    throw new AggregateException(ignoredExceptions);
            }
        }

        private static void ProcessDataInParallel(byte[] data) {
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(data, d => {
                try
                {
                    if (d<3)
                    {
                        throw new ArgumentException($"Value is {d}. Value must be greater than or equal to 3. ThreadId="+Thread.CurrentThread.ManagedThreadId);
                    }
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            });

            if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }

        }

        /// <summary>
        /// 编写具有线程局部变量的 Parallel.For 循环
        /// </summary>
        public static void ParallelForPara()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, 
                nums.Length, 
                () => 0, 
                (j, loop, subtotal) =>{subtotal += nums[j];return subtotal;},
                (x) => {
                    Console.WriteLine("data is {0}", x);
                    Interlocked.Add(ref total, x);
                });

            //Parallel.For<long>(0, 
            //    nums.Length, 
            //    () => { return 1; }, 
            //    (j, loop, subtotal) =>{
            //    subtotal += nums[j];
            //    return subtotal;
            //    }, 
            //    x => Interlocked.Add(ref total, x)
            //    );

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        /// <summary>
        /// 使用分区本地变量编写 Parallel.ForEach 循环
        /// </summary>
        public static void ParallelForEachPara() {

            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                        () => 0, // method to initialize the local variable
                                        (j, loop, subtotal) => // method invoked by the loop on each iteration
                                     {
                                            subtotal += j; //modify local variable
                                         return subtotal; // value to be passed to next iteration
                                     },
                                        // Method to be executed when each partition has completed.
                                        // finalResult is the final value of subtotal for a particular partition.
                                        (finalResult) => Interlocked.Add(ref total, finalResult)
                                        );

            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);
        }

    }
}
