using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.ClainOfResponsibility_责任链模式_
{
    internal class ClainOfResponsibilityDemo
    {
        public static void main1()
        {
            var cManager = new CommonManager("aaa");
            var mManager = new MajorManager("bbb");
            var gManager = new GeneralManager("ggg");

            cManager.Superior = mManager;
            mManager.Superior = gManager;

            var req0 = new Request
            {
                Number = 100,
                RequestType = RequestType.加薪,
                RequestContent = "我要加薪"
            };
            cManager.RequestApplications(req0);

            var req1 = new Request();
            req1.Number = 2;
            req1.RequestType = RequestType.请假;
            req1.RequestContent = "我要请假";
            cManager.RequestApplications(req1);

            var req3 = new Request();
            req3.Number = 10000;
            req3.RequestType = RequestType.加薪;
            req3.RequestContent = "我要加薪";
            cManager.RequestApplications(req3);
        }
    }
}
