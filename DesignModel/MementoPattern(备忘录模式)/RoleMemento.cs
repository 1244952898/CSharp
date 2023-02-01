using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.MementoPattern_备忘录模式_
{
    internal class RoleMemento
    {
        public int Vit { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public RoleMemento(int vit, int atk, int def)
        {
            Vit = vit;
            Atk = atk;
            Def = def;
        }
    }
}
