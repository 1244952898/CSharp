using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.多线程
{
    internal class SumCharacter
    {
        static async Task<int> SumCharacterAsync(IEnumerable<char> text)
        {
            int total = 0;
            foreach (char c in text)
            {
                int uncode = c;
                await Task.Delay(uncode);
                total += uncode;
            }

            await Task.Yield();
            return total;
        }

    }
}
