using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterLibrary
{
    public class Adaptee
    {
        //Provide full precition
        public double SpecificRequest(double a, double b)
        {
            return a / b;
        }
    }

    public interface ITarget
    {
        //Rough estimate
        string Request(int i);
    }

    public class Adapter : Adaptee, ITarget
    {

        #region ITarget Members
        public string Request(int i)
        {
            return "Rough estmate is" + (int)Math.Round(SpecificRequest(i, 3));
        }

        #endregion
    }
}
