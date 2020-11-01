using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DeleagetAndEvent.Program;

namespace DeleagetAndEvent.NewFolder1
{
    public class GreetPeopleModel
    {
        /// <summary>
        /// 在 GreetingManager 类的内部声明 delegate1 变量
        /// </summary>
        public event GreetingDelegate delegateEvent;
        public void GreetPeople(string name)
        {
            delegateEvent(name);
        }
    }
}
