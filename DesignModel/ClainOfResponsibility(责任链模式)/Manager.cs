using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ClainOfResponsibility_责任链模式_
{
    internal abstract class Manager
    {
        public Manager Superior { get;set; }

        public string Name { get; set; }
        public Manager(string name)
        {
            Name = name;
        }

        abstract public void RequestApplications(Request request);
    }
}
