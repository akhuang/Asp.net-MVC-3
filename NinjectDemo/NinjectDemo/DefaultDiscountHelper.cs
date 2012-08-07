using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        //public decimal DiscountSize { get; set; }

        private decimal _discountSize;
        public DefaultDiscountHelper(decimal sizeParam)
        {
            _discountSize = sizeParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (_discountSize / 100m * totalParam));
        }
    }
}
