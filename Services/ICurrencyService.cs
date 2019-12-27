using System.Linq;
using System.Threading.Tasks;
using CurrenciesAPI.Models;

namespace CurrenciesAPI.Services
{
    public interface ICurrencyService
    {
        Task<IOrderedEnumerable<Currency>> GetData();
    }
}