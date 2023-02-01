using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.InterpreterPattern_解释器_
{
    internal class InterpreterPatternDemo
    {
        public static void A()
        {
            var pc=new PlayContext();
            pc.PlayText = "O 2 E 0.5 G 0.5 A 3 E 0.5 D 3 E 0.5 G 0.5";
            Expression expression = null;
            while (pc.PlayText.Length>0)
            {
                string str = pc.PlayText.Substring(0, 1);
                switch (str)
                {
                    case "O":
                        expression=new NoteExpression(); break;
                    case "P":
                        expression=new ScaleExpression(); break;
                    default:
                        break;
                }
                expression.Interpret(pc);
            }
        }
    }
}
