using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        IValueCalculator calculator;

        public ShoppingCart(IValueCalculator calcParam)
        {
            calculator = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calculator.ValueProducts(Products);
        }
    }
}