using Aras.IOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.A
{
    internal class ArasInnovator
    {
        public void M()
        {
            HttpServerConnection httpServerConnection = IomFactory.CreateHttpServerConnection("http://localhost/InnovatorServer/", "InnovatorSolutions_test", "admin", "innovator");
            var item = httpServerConnection.Login();
            if (item.isError())
            {
            }
            Innovator inn = IomFactory.CreateInnovator(httpServerConnection);
            Item item1=inn.newItem();
        }
    }
}
