using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignLibrary.Decorator
{
    public interface IPizza
    {
        int GetPrice();
    }

    public class Pizza : IPizza
    {
        public int GetPrice()
        {
            return 10;
        }
    }
}
