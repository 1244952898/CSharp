﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ClainOfResponsibility_责任链模式_
{
    internal class MajorManager : Manager
    {
        public MajorManager(string name) : base(name)
        {
        }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == RequestType.请假 && request.Number <= 5)
            {
                Console.WriteLine($"{request.RequestContent}:{RequestType.请假} 数量{request.Number} 被批准");
            }
            else
            {
                if (this.Superior != null)
                {
                    this.Superior.RequestApplications(request);
                }
            }
        }
    }
}
