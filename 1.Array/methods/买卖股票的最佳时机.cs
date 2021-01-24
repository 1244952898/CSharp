using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Array.methods
{
    public class BuyMethod
    {
        #region 0

       
        public int MaxPrice { get; set; }

        public int GetMaxProfit(int[] prices)
        {
            if (prices==null||prices.Length<=1)
            {
                return 0;
            }
            this.MaxPrice = 0;
            dsf(prices, 0, prices.Length, 0, this.MaxPrice);
            return this.MaxPrice;
        }

        private void dsf(int[] prices,int i,int len,int status,int totalPrice)
        {
            if (i==len)
            {
                this.MaxPrice = Math.Max(this.MaxPrice, totalPrice);
                return;
            }
            dsf(prices, i + 1, len, status, 0);
            if (status==0)
            {
                dsf(prices, i + 1, len, 1, totalPrice - prices[i]);
            }
            else
            {
                dsf(prices, i + 1, len, 0, totalPrice + prices[i]);
            }
        }

        #endregion

        #region 1
        public int GetMaxProfit1(int[] prices)
        {
            if (prices==null|| prices.Length<=1)
            {
                return 0;
            }
            int len = prices.Length;
            int[][] priceModel = new int[len][];
            priceModel[0] = new int[2];
            priceModel[0][0] = 0;
            priceModel[0][1] = -prices[0];

            for (int i = 1; i < len; i++)
            {
                priceModel[i] = new int[2];
                priceModel[i][0] = Math.Max(priceModel[i - 1][0], priceModel[i - 1][1] + prices[i]);
                priceModel[i][1] = Math.Max(priceModel[i - 1][1], priceModel[i - 1][0] - prices[i]);
            }
            return priceModel[len - 1][0];
        }
        #endregion
    }
}
