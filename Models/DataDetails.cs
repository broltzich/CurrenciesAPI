using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesAPI.Models
{
    public class DataDetails
    {
        public string Date { get; set; }
        public string PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public string Timestamp { get; set; }
        public IDictionary<string, Currency> Valute { get; set; }
    }
}
