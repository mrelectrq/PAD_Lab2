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
    public class CurrencyController : ControllerBase
    {
        IServices services;
        public CurrencyController()
        {
            var _bl = new BusinessManager();
            services = _bl.Services();
        }

        [HttpGet]
        public ActionResult<CurrencyResponse> GetCurrency()
        {
            var response = services.GetCurrency();
            return response.Result;
        }
    }
}
