using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.MementoPattern_备忘录模式_
{
    internal class Role
    {
        public int Vit { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Name { get; set; }

        public Role()
        {
        }

        public void InitRole()
        {
            Vit = 10;
            Atk = 10;
            Def = 10;
        }

        public void Fight()
        {
            Vit = 10;
            Atk = 10;
            Def = 10;
        }

        public RoleMemento SaveState()
        {
            return new RoleMemento(Vit, Atk, Def);
        }

        public void RecoryState(RoleMemento roleMemento)
        {
            roleMemento.Vit = Vit;
            roleMemento.Atk = Atk;
            roleMemento.Def = Def;
        }

        public override string ToString()
        {
            return $"Vit:{Vit} Atk:{Atk} Def:{Def}";
        }
    }
}
