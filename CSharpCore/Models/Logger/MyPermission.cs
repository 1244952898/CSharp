using System;
using System.Linq;

namespace CSharpCore.Models.Logger
{
    [Flags]
    public enum MyPermission
    {
        Add = 8,
        Delete = 1,
        Edit = 2,
        Select=4
    }
}
