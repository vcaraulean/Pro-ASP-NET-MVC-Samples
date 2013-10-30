using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper {
        decimal ApplyDiscount(decimal total);
    }
    public class DiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }

        public decimal ApplyDiscount(decimal total)
        {
            return (total - (DiscountSize / 100m * total));
        }
    }

    public class FlexibleDiscounter : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal total)
        {
            var discount = total > 100 ? 70 : 25;
            return (total - (discount / 100m * total));
        }
    }

    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal total)
        {
            throw new NotImplementedException();
        }
    }

}