using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IServices services;
        public AccountController()
        {
            var _bl = new BusinessManager();
            services = _bl.Services();
        }

        [HttpPost]
        public ActionResult<AccountResponse> PostAccount([FromBody] AccountMessage message)
        {
            var response = services.GetAccount(message);
            return response.Result;
        }


    }
}
