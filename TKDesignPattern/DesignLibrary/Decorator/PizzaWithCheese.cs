using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignLibrary.Decorator
{
    //Decorator class
    public class PizzaWithCheese : IPizza
    {
        private IPizza _pizza;
        private int _priceofCheese;

        public PizzaWithCheese(IPizza pizza, int priceofCheese)
        {
            _pizza = pizza;
            _priceofCheese = priceofCheese;
        }

        public int GetPrice()
        {
            //get price of the base pizza and add price of cheese to it
            return _pizza.GetPrice() + _priceofCheese;
        }
    }
}
