using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qiniu1
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime st = DateTime.UtcNow;
            //DateTime.Now.Kind == DateTimeKind.Unspecified;
            DateTime time = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);


            Mac mac = new Mac("Q55UE0jgwwHxF8eH3bXCYAbTo7Q7I_QhJAiXk4gB", "6MuXJVexC7qsY8Iu9TbWXP4097TEx0IRIT8_LHtz");
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = "sensori-south-bucket.s3-cn-south-1.qiniucs.com";
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
        }
    }
}
