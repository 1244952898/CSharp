using System;
using System.Linq;

namespace CSharpCore.Models.Logger
{
    [Flags]
    public enum MySourceLevels
    {
        Off = 0,
        Critical = 0x01,
        Error = 0x03,
    }
}
