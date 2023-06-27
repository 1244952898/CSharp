using CSharp.字符串回文;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Queens;
using CSharp.ElsaticSearch;
using System.Text.RegularExpressions;
using System.Threading;
using Nest;
using Newtonsoft.Json;
using CSharp.TestInterface2;
using CSharp.copyTest;
using CSharp.多线程;
using CSharp.NodeTest;
using System.Globalization;
using CSharp.ISTest;
using System.Collections;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commonSql = @"
        SELECT 
            COUNT(M.RELATED_ID) qty
        FROM innovator.[IDENTITY] I
        JOIN innovator.MEMBER M ON I.ID=M.SOURCE_ID
        WHERE [NAME] = 'HS AUDITERS'
        AND M.RELATED_ID='{0}'
    ";
            var s1 = string.Format(commonSql, "a");
        }


    }

    public class Abc
    { 
        public List<string> names { get; set; }
    }
}
