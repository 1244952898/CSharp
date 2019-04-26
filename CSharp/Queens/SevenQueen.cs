using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Queens
{
    public class SevenQueen
    {
        public static bool[,] table = new bool[8, 8];
        public static int Count = 0;

        public static void MainMethod(int row) {
            if (row==8)
            {
                Count++;
                PrintMethod();
                return;
            }

            for (int col = 0; col < 8; col++)
            {
                if (CheckMethod(row,col))
                {
                    table[row, col] = true;
                    MainMethod(row + 1);
                    table[row, col] = false;
                }
            }
        }

        public static bool CheckMethod(int row,int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (table[i,col])
                {
                    return false;
                }
            }

            for (int i = row-1,j=col-1; i>=0&&j>=0; i--,j--)
            {
                if (table[i, j])
                {
                    return false;
                }
            }

            for (int i = row - 1, j = col + 1; i >= 0 && j <8; i--, j++)
            {
                if (table[i, j])
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintMethod()
        {
            Console.WriteLine("方案" + Count + ":" + "\n");
            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 8; m++)
                {
                    if (table[i, m])
                    {
                        //System.out.print("皇后"+(i+1)+"在第"+i+"行，第"+m+"列\t");
                        Console.Write("o ");
                    }
                    else
                    {
                        Console.Write("+ ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("==================");
        }
    }
}
