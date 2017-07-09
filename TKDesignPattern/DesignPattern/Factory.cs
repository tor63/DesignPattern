using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
      interface IProduct
    {
        string ShipFrom();
    }
    class ProductA : IProduct
    {
        public string ShipFrom()
        {
            return " from Norway";
        }
    }
    class ProductB : IProduct
    {
        public string ShipFrom()
        {
            return " from Sweden";
        }
    }
    class ProductDefault : IProduct
    {
        public string ShipFrom()
        {
            return " NA";
        }
    }

    class Creator
    {
        public IProduct FactoryMethod(int month)
        {
            if (month >= 4)
                return new ProductA();
            else if (month == 1)
                return new ProductB();
            else
                return new ProductDefault();
        }
    }


}
