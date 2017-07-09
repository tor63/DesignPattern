using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignLibrary
{
    //Concern: End of the chain
    public class ChainOfResponsibility
    {
        public void CallHelpDesk(string s)
        {
            try
            {
                Method1(s);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught in CallHelpDesk");
            }
        }

        private void Method1(string s)
        {
            try
            {
                Method2(s);

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Caught in Method1");
            }
        }

        private void Method2(string s)
        {
            try
            {
                switch (s)
                {
                    case "AccessViolationException":
                        throw new AccessViolationException();
                    case "NullReferenceException":
                        throw new NullReferenceException();
                    case "ArgumentException":
                        throw new ArgumentException();
                    default:
                        throw new Exception();
                }

            }
            catch (AccessViolationException)
            {
                Console.WriteLine("Caught in Method2");
            }
        }
    }
}
