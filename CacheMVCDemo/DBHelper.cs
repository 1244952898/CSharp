using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace CacheMVCDemo
{
    public class DBHelper
    {
        public List<Person> GetData(out string msg)
        {
            //尝试从缓存中取出数据
            var data = HttpContext.Current.Cache.Get("GetData");
            if (data==null)
            {
                string sql = "select * from person;";
                using (var connection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True"))
                {
                   var da= connection.Query<Person>(sql).ToList();
                    HttpContext.Current.Cache.Insert("GetData", da,new SqlCacheDependency("test", "Person"));
                    msg = "数据来源：数据库";
                    return da;
                }
            }
            else
            {
                msg = "数据来源：缓存";
                return (List<Person>)data;
            }
        }
        
    }
}