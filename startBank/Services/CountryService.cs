using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Pages;
using System.Security.Cryptography.X509Certificates;

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
        // each country


        public int GetCustomerCount(string country)
        {
            return _dbContext.Customers
                .Count(c => c.Country == country);
        }

        public int GetAccountCount(string country)
        {
            var numberOfAccounts = _dbContext.Customers
                .Where(c => c.Country == country)
                .Join(_dbContext.Dispositions, c => c.CustomerId, d => d.CustomerId, (c, d) => new { Customer = c, Disposition = d })
                .Join(_dbContext.Accounts, cd => cd.Disposition.AccountId, a => a.AccountId, (cd, a) => new { CustomerDisposition = cd, Account = a })
                .Select(cda => cda.Account.AccountId)
                .Distinct()
                .Count();

            return numberOfAccounts;
        }

        public decimal GetTotalCapital(string country)
        {
            var totalCapital = _dbContext.Customers
                .Where(c => c.Country == country)
                .Join(_dbContext.Dispositions, c => c.CustomerId, d => d.CustomerId, (c, d) => d.AccountId)
                .Join(_dbContext.Accounts, accountId => accountId, account => account.AccountId, (accountId, account) => account.Balance)
                .Sum();

            return totalCapital;
        }




    }
}
