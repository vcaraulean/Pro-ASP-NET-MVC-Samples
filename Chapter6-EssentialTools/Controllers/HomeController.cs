using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        IValueCalculator calculator;

        public HomeController(IValueCalculator calculator)
        {
            this.calculator = calculator;
        }

        private Product[] products = {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "Lifejacket", Price = 48.95M},
                new Product { Name = "Soccer ball", Price = 19.50M},
                new Product { Name = "Corner flag", Price= 34.5M},
                                     };
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var cart = new ShoppingCart(calculator) { Products = products };
            var totalValuee = cart.CalculateProductTotal();
            return View(totalValuee);
        }
    }
}
