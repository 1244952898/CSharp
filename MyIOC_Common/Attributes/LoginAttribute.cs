using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common.Attributes
{
    public class LoginAttribute:AbstractAttribute
    {
        public override Action Do(Action action)
        {
            return new Action(() =>
            {
                Console.WriteLine($"Do some things for {this.GetType().FullName}======1.1");
                action.Invoke();
                Console.WriteLine($"Do some things for {this.GetType().FullName}======1.2");
            });
            
        }
    }
}
