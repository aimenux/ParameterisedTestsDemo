using Lib.Models;

namespace Lib
{
    public interface IPricer
    {
        decimal Compute(Product product);
        decimal Compute(Basket basket);
    }
}
