using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CurrenciesAPI.Models;
using CurrenciesAPI.Services;
using CurrenciesAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrenciesAPI.Controllers
{
    [ResponseCache(Duration = 15)]
    [Route("api/[controller]")]
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyService _ctx;

        public CurrenciesController(ICurrencyService service)
        {
            _ctx = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCurrencies(int pageNumber, int amount)
        {
            if (pageNumber < 1 || amount < 1)
            {
                return BadRequest();
            }

            var data = await _ctx.GetData();
            var currencies = data.Skip((pageNumber - 1) * amount).Take(amount);
            var toReturn = new PagedList
            {
                PageNumber = pageNumber,
                LastPage = (data.Count() % amount == 0) ? (data.Count() / amount) : (data.Count() / amount + 1),
                Currencies = currencies,
                Count = data.Count()
            };
            return Ok(toReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrency(string id)
        {
            var data = await _ctx.GetData();
            var result = data.FirstOrDefault(r => r.ID == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}