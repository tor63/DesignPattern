using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK.DesignPattern.DAL;
using System.Collections.Generic;
using DesignLibrary;
using System.Linq;
using DesignLibrary.Decorator;

namespace TK.DesignLibrary.UnitTest
{
    [TestClass]
    public class DecoratorTest
    {
        [TestMethod]
        public void Pizza_GetPrice_Price()
        {
            var pizza = new Pizza();
            var price = pizza.GetPrice();

            Assert.IsNotNull(price);
            Assert.AreEqual(10, price);
        }
        [TestMethod]
        public void PizzaDecorator_GetPriceWithCheese_Price()
        {
            var pizza = new PizzaWithCheese(new Pizza(), 3);
            var price = pizza.GetPrice();

            Assert.IsNotNull(price);
            Assert.AreEqual(13, price);
        }
    }
}
