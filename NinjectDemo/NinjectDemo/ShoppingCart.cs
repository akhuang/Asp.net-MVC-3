using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public class ShoppingCart
    {
        private IValueCalculator calculator;

        public ShoppingCart(IValueCalculator calcParam)
        {
            calculator = calcParam;
        }

        public decimal CalculateStockValue()
        {
            Product[] products = { 
                                    new Product(){Name="Kayak",  Price=275M},
                                    new Product() { Name = "Lifejacket", Price = 48.95M},
                                    new Product() { Name = "Soccer ball", Price = 19.50M},
                                    new Product() { Name = "Stadium", Price = 79500M}
                                  };
            decimal totalValue = calculator.ValueProducts(products);
            return totalValue;
        }
    }
}
