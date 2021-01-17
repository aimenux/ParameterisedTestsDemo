using Lib.Models;
using System.Linq;

namespace Lib
{
    public class Pricer : IPricer
    {
        public decimal Compute(Product product)
        {
            return product.Quantity * product.UnitPrice;
        }

        public decimal Compute(Basket basket)
        {
            return basket.Sum(p => Compute(p));
        }
    }
}
