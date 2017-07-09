using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignLibrary
{
    public  interface IProduct
    {
        string ShipFrom();
    }
    public class ProductA : IProduct
    {
        public string ShipFrom()
        {
            return " from Norway";
        }
    }
    public class ProductB : IProduct
    {
        public string ShipFrom()
        {
            return " from Sweden";
        }
    }
    public class ProductDefault : IProduct
    {
        public string ShipFrom()
        {
            return " NA";
        }
    }

    public class Creator
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
