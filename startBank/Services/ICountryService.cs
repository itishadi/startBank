
using startBank.Models;
using System.Diagnostics.Metrics;

namespace startBank.Services
{
    public interface ICountryService
    {
        List<CustomerModel> GetTopCustomers(string country);
        public int GetCustomerCount(string country);
        public int GetAccountCount(string country);
        public decimal GetTotalCapital(string country);
    }

}
