using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ClainOfResponsibility_责任链模式_
{
    internal class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name)
        {
        }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == RequestType.请假 )
            {
                Console.WriteLine($"{request.RequestContent}:{RequestType.请假} 数量{request.Number} 被批准");
            }
            else if (request.RequestType == RequestType.加薪 && request.Number <= 1000)
            {
                Console.WriteLine($"{request.RequestContent}:{RequestType.加薪} 数量{request.Number} 被批准");
            }
            else if (request.RequestType == RequestType.加薪 && request.Number > 1000)
            {
                Console.WriteLine($"再考虑吧");
            }
        }
    }
}
