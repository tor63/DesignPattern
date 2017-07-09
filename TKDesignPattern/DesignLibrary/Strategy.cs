using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignLibrary
{
    public class Context
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

    public interface IStrategy
    {
        int Move(Context c);
    }

    public class StrategyA : IStrategy
    {
        public int Move(Context c)
        {
            return ++c.counter;
        }
    }

    public class StrategyB : IStrategy
    {
        public int Move(Context c)
        {
            return --c.counter;
        }
    }

}
