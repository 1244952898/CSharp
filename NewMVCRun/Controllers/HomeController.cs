﻿using NewMVC;
using NewMVCRun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMVCRun.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            HttpContext.Current.Response.Write("Hello MVC");
        }

        public void BootstrapTest()
        {
            var lstUser = new List<User>();
            lstUser.Add(new User() { Id = 1, UserName = "Admin", Age = 20, Address = "北京", Remark = "超级管理员" });
            lstUser.Add(new User() { Id = 2, UserName = "张三", Age = 37, Address = "湖南", Remark = "呵呵" });
            lstUser.Add(new User() { Id = 3, UserName = "王五", Age = 32, Address = "广西", Remark = "呵呵" });
            lstUser.Add(new User() { Id = 4, UserName = "韩梅梅", Age = 26, Address = "上海", Remark = "呵呵" });
            lstUser.Add(new User() { Id = 5, UserName = "呵呵", Age = 18, Address = "广东", Remark = "呵呵" });

            string strUser = string.Empty;
            foreach (var oUser in lstUser)
            {
                strUser += "<tr><td>" + oUser.Id + "</td><td>" + oUser.UserName + "</td><td>" + oUser.Age + "</td><td>" + oUser.Address + "</td><td>" + oUser.Remark + "</td></tr>";
            }

            HttpContext.Current.Response.Write(@"
<html>
    <head>
        <link href='/Content/bootstrap/css/bootstrap.min.css' rel='stylesheet' />
        <script src='/Content/jquery-1.9.1.min.js'></script>
        <script src='/Content/bootstrap/js/bootstrap.min.js'></script>
    </head>
    <body>
         <div class='panel-body' style='padding-bottom:0px;'>
        <div class='panel panel-primary'>
            <div class='panel-heading'>bootstrap表格</div>
            <div class='panel-body'>
                <table id='tbarrivequeue' class='table table-bordered table-striped'>
                    <thead>
                        <tr>
                            <th>用户ID</th>
                            <th>用户名</th>
                            <th>年龄</th>
                            <th>地址</th>
                            <th>备注</th>
                        </tr>
                    </thead>
                    <tbody>
                       " + strUser + @"
                    </tbody>
                </table>
            </div>
        </div>  
     </div>     

        
    </div>
    </body>
</html>");

        }
    }
}