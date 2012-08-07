using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public interface IValueCalculator
    {
        decimal ValueProducts(params Product[] products);
    }
}
