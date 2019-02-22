using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleagetAndEvent
{
    public class IPhone6
    {
        decimal price;
        public event EventHandler<PriceChangedEventArgs> priceChange;

        protected virtual void OnPriceChange(PriceChangedEventArgs e)
        {
            if (priceChange==null)
            {
                return;
            }
            priceChange(this,e);
        }

        public decimal Price {
            get
            {
                return price;
            }
            set
            {
                if (value==price)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                if (priceChange != null)
                    OnPriceChange(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }
}
