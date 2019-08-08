using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 异步多线程学习
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"id={this.Id} name={this.Name}";
        }
    }
}
