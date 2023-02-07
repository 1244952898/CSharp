using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesla.q2
{
    public class ProductRecord
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
    public class WarehouseEntry
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class a
    {
        public void t()
        {
            IEnumerable<WarehouseEntry> warehouseEntries= new List<WarehouseEntry>();
            IEnumerable<ProductRecord> productRecords= new List<ProductRecord>();
            var res = productRecords.Select(x =>
            {
                return new WarehouseEntry
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                };
            }).FirstOrDefault();
        }
    }
}
