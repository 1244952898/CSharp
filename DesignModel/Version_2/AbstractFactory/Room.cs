using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.Version_2.AbstractFactory
{
    internal class Room
    {
        public int No { get; set; }

        public IMapeSite[] Directions = new IMapeSite[4];



        public Room(int no)
        {
            this.No = no;
        }

        public void SetSize(IMapeSite site, DirectionEnum direction)
        {
            var i = (int)direction;
            Directions[i] = site;
        }

        public void Enter()
        {
            Console.WriteLine("");
        }
    }
}
