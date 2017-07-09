using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
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

    class Factory1 : IFactory
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
    class Factory2 : IFactory
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

    class ProductCar1 : IProductCar
    {
        public string getMerke()
        {
            return "Volvo";
        }
    }
    class ProductCar2 : IProductCar
    {
        public string getMerke()
        {
            return "Audi";
        }
    }

    class ProductBike1 : IProductBike
    {
        public int getSize()
        {
            return 20;
        }
    }
    class ProductBike2 : IProductBike
    {
        public int getSize()
        {
            return 30;
        }
    }

}
