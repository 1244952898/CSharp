using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.MementoPattern_备忘录模式_
{
    internal class MementoPatternDemo
    {
        /*
         * 1、后悔药。 
         * 2、打游戏时的存档。
         * 3、Windows 里的 ctrl + z。
         * 4、IE 中的后退。 
         * 5、数据库的事务管理。
         */
        public static void main()
        {
            Role role= new Role();
            role.InitRole();
            Console.WriteLine(role.ToString());

            RoleMementoCareTaker roleMementoCareTaker=new RoleMementoCareTaker();
            roleMementoCareTaker.RoleMemento = role.SaveState();
            
            role.Fight();
            Console.WriteLine(role.ToString());

            role.RecoryState(roleMementoCareTaker.RoleMemento);
            Console.WriteLine(role);

        }
    }
}
