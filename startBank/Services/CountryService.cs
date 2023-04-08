using Microsoft.EntityFrameworkCore;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Pages;

namespace startBank.Services
{
    public class CountryService : ICountryService
    {
        private readonly BankAppDataContext _dbContext;

        public CountryService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomerModel> GetTopCustomers(string country)
        {
            var top10Customers = _dbContext.Customers
                .Where(c => c.Country == country)
                .Select(c => new
                {
                    Customer = c,
                    TotalBalance = _dbContext.Dispositions
                        .Where(d => d.CustomerId == c.CustomerId)
                        .Join(_dbContext.Accounts, d => d.AccountId, a => a.AccountId, (d, a) => a.Balance)
                        .Sum()
                })
                .OrderByDescending(c => c.TotalBalance)
                .Take(10)
                .Select(c => new CustomerModel
                {
                    Id = c.Customer.CustomerId,
                    Name = c.Customer.Givenname,
                    LastName = c.Customer.Surname,
                    Balance = c.TotalBalance
                })
                .ToList();

            return top10Customers;
        }



    }
}
