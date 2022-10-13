using IBLL;
using MyIOC_Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public  class Microphone: IMicrophone
    {
        public IHeadphone _IHeadphone { get; set; }
        public IHeadphone _IHeadphoneFeild { get; set; }

        [PropertyInjectionAttribute]
        public IServiceA _IServiceA { get; set; }

        public void SetHeadphone(IHeadphone headphone)
        {
            _IHeadphoneFeild = headphone;
        }

        [SelectCtorAttribute]
        public Microphone(IHeadphone headphone)
        {
            Console.WriteLine($"{this.GetType().Name}被构造,一个参数");
        }

        public Microphone(IHeadphone headphone, IHeadphone headphone1)
        {
            Console.WriteLine($"{this.GetType().Name}被构造,两个参数");
        }
    }
}
