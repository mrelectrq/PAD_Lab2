using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DBModels;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        IServices services;
        public TransactionController()
        {
            var _bl = new BusinessManager();
            services = _bl.Services();
        }

        [HttpPost]
        public ActionResult<TransactionResponse> PostTransaction([FromBody] TransactionMessage message)
        {
            var response = services.GetTransaction(message);
            return response.Result;
        }

        [HttpGet("{client_id}")]

        public ActionResult<List<Transactions>> GetResult(int client_id )
        {
           var transactions=  services.SearchTransaction(client_id);

            return transactions;
        }
    }
}
