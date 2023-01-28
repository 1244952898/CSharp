using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.InterpreterPattern_解释器_
{
    internal class NoteExpression : Expression
    {
        public override void Execute(string playKey, double playValue)
        {
            string note = "";
            switch (playKey)
            {
                case "C":
                    note = "1";
                    break;
                case "D":
                    note = "2";
                    break;
                case "E":
                    note = "3";
                    break;
                case "F":
                    note = "4";
                    break;
                case "G":
                    note = "5";
                    break;
                case "A":
                    note = "6";
                    break;
                case "B":
                    note = "7";
                    break;
                default:
                    break;
            }
            Console.WriteLine($"{note} ");
        }
    }
}
