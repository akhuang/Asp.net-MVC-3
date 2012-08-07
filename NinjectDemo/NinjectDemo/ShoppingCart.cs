using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public class ShoppingCart
    {
        public IValueCalculator calculator;
        public Product[] products;
        public ShoppingCart(IValueCalculator calcParam)
        {
            calculator = calcParam;

            products = new[] { 
                                    new Product(){Name="Kayak",  Price=275M},
                                    new Product() { Name = "Lifejacket", Price = 48.95M},
                                    new Product() { Name = "Soccer ball", Price = 19.50M},
                                    new Product() { Name = "Stadium", Price = 79500M}
                                  };
        }

        public virtual decimal CalculateStockValue()
        {
            decimal totalValue = calculator.ValueProducts(products);
            return totalValue;
        }
    }

    public class LimitShoppingCart : ShoppingCart
    {
        public decimal ItemLimit { get; set; }

        public LimitShoppingCart(IValueCalculator calcParam)
            : base(calcParam)
        { }

        public override decimal CalculateStockValue()
        {
            var filterProducts = products.Where(e => e.Price < ItemLimit);
            return calculator.ValueProducts(filterProducts.ToArray());
        }
    }
}
