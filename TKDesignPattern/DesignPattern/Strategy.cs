﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
       class Context
    {
        public int _START = 5;
        public int counter = 5;

        IStrategy strategy = new StrategyA();

        public int Algorithm()
        {
            return strategy.Move(this);
        }

        public void SwitchStrategy()
        {
            if (strategy is StrategyA)
                strategy = new StrategyB();
            else
                strategy = new StrategyA();
        }
    }

    interface IStrategy
    {
        int Move(Context c);
    }

    class StrategyA : IStrategy
    {
        public int Move(Context c)
        {
            return ++c.counter;
        }
    }

    class StrategyB : IStrategy
    {
        public int Move(Context c)
        {
            return --c.counter;
        }
    }

}
