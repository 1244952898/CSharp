using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Classes
{
    public class Decorator
    {
        public interface IUserProcessor
        {
            void RegUser(User user);
        }

        public class UserProcessor: IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。Name:{0},PassWord:{1}", user.Name, user.Password);
            }
        }

        public class UserDecorator : IUserProcessor
        {
            private IUserProcessor userProcessor;
            public UserDecorator(IUserProcessor _userProcessor) {
                userProcessor = _userProcessor;
            }
            public void RegUser(User user)
            {
                PreProceed(user);
                try
                {
                    userProcessor.RegUser(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                PostProceed(user);
            }

            public void PreProceed(User user)
            {
                Console.WriteLine("方法执行前");
            }

            public void PostProceed(User user)
            {
                Console.WriteLine("方法执行后");
            }

        }

        public static void Show()
        {
            User user = new User() { Name = "Eleven", Password = "123123123123" };
            IUserProcessor processor = new UserProcessor();
            processor = new UserDecorator(processor);
            processor.RegUser(user);
        }
    }
}
