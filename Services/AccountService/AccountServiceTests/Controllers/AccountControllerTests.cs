using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using Microsoft.AspNetCore.Http.Connections;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http;

namespace AccountService.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            var controller = new AccountController();
           



            var data = new AccountMessage();
            data.AccountId = "1";
            data.Balance = 2;
            data.FirstName = "Ionas";
            data.LastName = "cristi";


            var response = controller.Post(data);
            Assert.IsNotNull(response);
        }


    }
}

namespace AccountServiceTests.Controllers
{
    class AccountControllerTests
    {
    }
}
