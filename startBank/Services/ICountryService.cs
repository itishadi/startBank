
using startBank.Models;
using System.Diagnostics.Metrics;

namespace startBank.Services
{
    public interface ICountryService
    {
        List<CustomerModel> GetTopCustomers(string country);
    }
}
