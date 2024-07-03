using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class MyAsyncStateMachine : IAsyncStateMachine
    {
        #region Fields

        public int state;
        public AsyncTaskMethodBuilder builder;
        public string[] args;
        private TaskAwaiter u;

        #endregion
        public void MoveNext()
        {
            // 在 Main 方法中，我们初始化 <>1__state = -1，所以此时 num = -1
            int num = state;
            try
            {
                TaskAwaiter awaiter;
                if (num!=0)
                {
                    Console.WriteLine("Let's Go!");
                    // 调用 TestAsync()，获取 awaiter，用于后续监控 TestAsync() 运行状态
                    awaiter = Program.TestAsync().GetAwaiter();

                    // 一般来说，异步任务不会很快就完成，所以大多数情况下都会进入该分支
                    if (!awaiter.IsCompleted)
                    {
                        // 状态机状态从 -1 流转为 0
                        state = num = 0;
                        u = awaiter;
                        //Program.< Main > d__0 stateMachine = this;
                        //// 配置  TestAsync() 完成后的延续
                        //this.<> t__builder.AwaitUnsafeOnCompleted <TaskAwaiter, Program.<Main>d__0> (ref awaiter, ref stateMachine);
                        //return;
                    }
                }
                else
                {
                    awaiter = this.u;
                    u = new TaskAwaiter();
                    state = num = -1;
                }
                awaiter.GetResult();
                Console.Write(" World!");
            }
            catch (Exception exception)
            {
                state = -2;
                builder.SetException(exception);
                return;
            }
            state = -2;
            builder.SetResult();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            throw new NotImplementedException();
        }
    }
}
