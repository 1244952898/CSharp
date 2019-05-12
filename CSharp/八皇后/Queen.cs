using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.八皇后
{
    public class Queen
    {
        public int row { get; set; }
        public int col { get; set; }
    }

    public class QueenMethod
    {
       static int queenCount = 8;//皇后数
       static Queen[] Queens = new Queen[queenCount];
        public void MainMethod()
        {
            DealMethod(0);
        }

        public void DealMethod(int row)
        {
            for (int col = 0; col < queenCount; col++)
            {
                if (row==0)
                {
                    Queens[row] = new Queen {row=row,col=col };
                    row++;
                    DealMethod(row);
                    break;
                }
                if (JudgeMethod(row, col))
                {
                    Queens[row] = new Queen { row = row, col = col };
                    row++;
                    DealMethod(row);
                    break;
                }
            }

            for (int i = 0; i < Queens.Length; i++)
            {
                for (int j = 0; j < Queens.Length; j++)
                {
                    if (j== Queens[i].col)
                    {
                        Console.Write("■");
                    }
                    else
                    {
                        Console.Write("□");
                    }
                    Console.Write("\n");
                }
            }

        }

        /// <summary>
        /// 是否可以放
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool JudgeMethod(int row, int col)
        {
            for (int i = row-1; i >=0; i--)
            {
                if (Queens[i].col==col|| Queens[i].row- row == Queens[i].row -col)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
