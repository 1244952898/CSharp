using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.Version_2.AbstractFactory
{
    internal interface IAbstractFactory
    {
        Room CreateRoom(int no);
        Door CreateDoor(Room room0,Room room1);
        Wall CreateWall();
    }
}
