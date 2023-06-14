using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.Version_2.AbstractFactory
{
    internal class ConcreteFactory0 : IAbstractFactory
    {
        public Door CreateDoor(Room room0, Room room1)
        {
            return new Door(room0,room1);
        }

        public Room CreateRoom(int no)
        {
            return new Room(no);
        }

        public Wall CreateWall()
        {
            return new Wall();
        }
    }
}
