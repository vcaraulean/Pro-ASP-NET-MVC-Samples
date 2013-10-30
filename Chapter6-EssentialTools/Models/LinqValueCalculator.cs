using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }

    public class LinqValueCalculator : IValueCalculator
    {
        IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discounter)
        {
            this.discounter = discounter;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}