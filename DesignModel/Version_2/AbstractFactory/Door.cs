using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.Version_2.AbstractFactory
{
    internal class Door:IMapeSite
    {
        public Room r0 { get; set; }
        public Room r1 { get; set; }
        public Door(Room r0, Room r1)
        {
            this.r0 = r0;
            this.r1 = r1; 
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }
    }
}
