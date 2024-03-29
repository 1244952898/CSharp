﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.InterpreterPattern_解释器_
{
    internal abstract class Expression
    {
        public void Interpret(PlayContext context)
        {
            if (context.PlayText.Length<=0)
            {
                return;
            }
            else
            {
                string playKey = context.PlayText.Substring(0, 1);
                context.PlayText = context.PlayText.Substring(0, 2);
                double playValue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                context.PlayText = context.PlayText.Substring(context.PlayText.IndexOf(" ") + 1);

                Execute(playKey, playValue);
            }
        }

        public abstract void Execute(string playKey, double playValue);
    }
}
