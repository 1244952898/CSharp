using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Queens
{
    public class Queen
    {
        public static int[,] arry = new int[8,8];//棋盘，放皇后
        public static int map = 0;//存储方案结果数量

        public static void FindQueen(int row)
        {
            if (row>7)
            {
                map++;
                PrintQueen();
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                if (CheckQueen(row,i))
                {
                    arry[row, i] = 1;
                    FindQueen(row+1);
                    arry[row, i] = 0;
                }
            }
            
        }

        private static bool CheckQueen(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (arry[i, col]==1)
                {
                    return false;
                }
            }

            for (int a = row-1,b=col-1; a>=0&&b>=0; a--,b--)//left
            {
                if (arry[a, b] == 1)
                {
                    return false;
                }
            }

            for (int a = row - 1, b = col + 1; a >= 0 && b <8; a--, b++)//left
            {
                if (arry[a, b] == 1)
                {
                    return false;
                }
            }

            return true;

        }

        private static void PrintQueen()
        {
            Console.WriteLine("方案" + map + ":" + "\n");
            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 8; m++)
                {
                    if (arry[i,m] == 1)
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
