using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace NinjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IDiscountHelper>()
                .To<DefaultDiscountHelper>()
                .WithConstructorArgument("sizeParam", 50M);
            //.WithPropertyValue("DiscountSize", 20M);
            IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calcImpl);
            Console.WriteLine("Total:{0:c} ", cart.CalculateStockValue());

            //Ninject SelfBinding
            ShoppingCart selfBindingCart = ninjectKernel.Get<ShoppingCart>();
            Console.WriteLine("Total:{0:c} ", selfBindingCart.CalculateStockValue());

            //Self binding with parameters
            //ninjectKernel.Bind<ShoppingCart>().ToSelf().WithPropertyValue("", "");

            ninjectKernel.Bind<ShoppingCart>().To<LimitShoppingCart>().WithPropertyValue("ItemLimit", 200M);
            ShoppingCart derivedTypeBindingCart = ninjectKernel.Get<ShoppingCart>();
            Console.WriteLine("Total:{0:c} ", derivedTypeBindingCart.CalculateStockValue());

            //Conditional Binding Methods
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IValueCalculator>()
            .To<IterativeValueCalculator>()
            .WhenInjectedInto<LimitShoppingCart>();

            Console.ReadKey();
        }
    }
}
