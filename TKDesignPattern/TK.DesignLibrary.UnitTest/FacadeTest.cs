using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK.DesignPattern.DAL;
using System.Collections.Generic;
using DesignLibrary;
using System.Linq;

namespace TK.DesignLibrary.UnitTest
{
    [TestClass]
    public class FacadeTest
    {
        [TestMethod]
        public void Facade_ForEach()
        {
            var f = new FacadeForEach();
            Assert.IsNotNull(f);
        }
    }
}
