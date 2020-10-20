using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proxy.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.Controllers.Tests
{
    [TestClass()]
    public class TestControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            try
            {
                var controller = new TestController();
                controller.Get();
            }
            catch { }
        }
    }
}

