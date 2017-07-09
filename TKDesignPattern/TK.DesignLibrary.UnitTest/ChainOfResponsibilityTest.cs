using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK.DesignPattern.DAL;
using System.Collections.Generic;
using DesignLibrary;
using System.Linq;

namespace TK.DesignLibrary.UnitTest
{
    [TestClass]
    public class ChainOfResponsibilityTest
    {
        ChainOfResponsibility _cor = null;

        [TestInitialize]
        public void Setup()
        {
            _cor = new ChainOfResponsibility();
        }


        [TestMethod]
        public void ChainOfResponsibility_CallHelpDesk_NoError()
        {
            _cor.CallHelpDesk("AccessViolationException");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "")]
        public void ChainOfResponsibility_CallHelpDesk_ExceptionIsThrown()
        {
            _cor.CallHelpDesk("Should trow an exception");
        }
    }
}
