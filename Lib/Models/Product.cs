using System;

namespace Lib.Models
{
    public class Product
    {
        public Product() : this(0, 0)
        {
        }

        public Product(int quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
