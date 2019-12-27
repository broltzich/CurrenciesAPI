using CurrenciesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesAPI.ViewModels
{
    public class PagedList
    {
        public int PageNumber { get; set; }
        public int LastPage { get; set; }
        public int Count { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
    }
}
