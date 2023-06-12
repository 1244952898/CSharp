using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.Version_2.AbstractFactory
{
    internal class Demo
    {
        public static void m()
        {
            var factory = new ConcreteFactory0();
            var room0 = factory.CreateRoom(0);
            var room1 = factory.CreateRoom(1);

            var door=factory.CreateDoor(room0,room1);

            room0.SetSize(door, DirectionEnum.East);
            room0.SetSize(factory.CreateWall(), DirectionEnum.West);
            room0.SetSize(factory.CreateWall(), DirectionEnum.North);
            room0.SetSize(factory.CreateWall(), DirectionEnum.South);

            room1.SetSize(factory.CreateWall(), DirectionEnum.East);
            room1.SetSize(door, DirectionEnum.West);
            room1.SetSize(factory.CreateWall(), DirectionEnum.North);
            room1.SetSize(factory.CreateWall(), DirectionEnum.South);
        }
    }
}
