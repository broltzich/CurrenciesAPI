using CurrenciesAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrenciesAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _client;

        public CurrencyService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IOrderedEnumerable<Currency>> GetData()
        {
            var data = await _client.GetStringAsync("daily_json.js");
            var currencyData = JsonConvert.DeserializeObject<DataDetails>(data);
            return currencyData.Valute.Values.OrderBy(c => c.CharCode);
        }
    }
}
