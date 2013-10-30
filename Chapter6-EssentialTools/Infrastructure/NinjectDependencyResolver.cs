using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyResolver() 
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IDiscountHelper>().To<DiscountHelper>().WithPropertyValue("DiscountSize", 50M);

            kernel.Bind<IDiscountHelper>().To<FlexibleDiscounter>().WhenInjectedInto<LinqValueCalculator>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}