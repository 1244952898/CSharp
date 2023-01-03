using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignModel.BuilderPattern
{
    internal class Meal
    {
        public List<IItem> list =new List<IItem>();
        public void AddItem(IItem item)
        {
            list.Add(item);
        }

        public float GetPrice()
        {
            var total = list.Sum(item => item.Price());
           return total;
        }

        public void ShowItems()
        {
            list.ForEach(item =>
            {
                Console.WriteLine($"{item.Name()}-{item.Price()}-{item.Packing()}");
            });
        }
    }
}
