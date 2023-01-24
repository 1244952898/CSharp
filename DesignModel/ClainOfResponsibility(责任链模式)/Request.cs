using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ClainOfResponsibility_责任链模式_
{
    internal class Request
    {
        public RequestType RequestType { get; set; }
        public string RequestContent { get; set; }
        public int Number { get; set; }
    }

    public enum RequestType
    {
        请假,
        加薪,
        
    }
}
