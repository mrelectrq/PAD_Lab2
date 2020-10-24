using BusinessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void PostTransactionTest()
        {

            var messasge = new TransactionMessage()
            {
                AccountOwnerId = 125123123,
                AccountReceiverId = 1252112,
                Currency = "MDL",
                Amount = 123123.23
            };

            var serialize_msg = JsonConvert.SerializeObject(messasge);


            Assert.Fail();
        }
    }
}