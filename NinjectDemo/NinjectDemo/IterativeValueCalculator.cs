using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public class IterativeValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        public IterativeValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }
        public decimal ValueProducts(params Product[] products)
        {
            decimal total = 0;
            foreach (var item in products)
            {
                total += item.Price;
            }
            return discounter.ApplyDiscount(total);
        }
    }
}
