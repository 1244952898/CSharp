using MyAttribute.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("特性和AOP");
                People people = new People();
                UserModel userModel=new UserModel();
                userModel.Id = 23;
                string remark = userModel.GetTableName();
                BaseDAL.Save<UserModel>(userModel);

                #region AOP show

                Console.WriteLine("***********************");
                Decorator.Show();

                Console.WriteLine("***********************");
                Proxy.Show();

                Console.WriteLine("***********************");
                CastleProxy.Show();

                Console.WriteLine("***********************");
                UnityAOP.Show();

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
            Console.Read();
        }
    }
}
