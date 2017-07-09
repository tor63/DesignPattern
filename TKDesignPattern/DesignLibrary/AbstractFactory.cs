using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignLibrary
{
    public interface IFactory
    {
        IProductCar getCar();
        IProductBike getBike();
    }

    public interface IProductCar
    {
        string getMerke();
    }

    public interface IProductBike
    {
        int getSize();
    }

    public class Factory1 : IFactory
    {
        public IProductCar getCar()
        {
            return new ProductCar1();
        }

        public IProductBike getBike()
        {
            return new ProductBike1();
        }
    }
    public class Factory2 : IFactory
    {
        public IProductCar getCar()
        {
            return new ProductCar2();
        }

        public IProductBike getBike()
        {
            return new ProductBike2();
        }
    }

    public class ProductCar1 : IProductCar
    {
        public string getMerke()
        {
            return "Volvo";
        }
    }
    public class ProductCar2 : IProductCar
    {
        public string getMerke()
        {
            return "Audi";
        }
    }

    public class ProductBike1 : IProductBike
    {
        public int getSize()
        {
            return 20;
        }
    }
    public class ProductBike2 : IProductBike
    {
        public int getSize()
        {
            return 30;
        }
    }

}
