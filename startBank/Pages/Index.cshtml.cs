using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ICountryService _countryService;

        public IndexModel(ICountryService countryService)
        {
            _countryService = countryService;
        }


        public List<int> Customers { get; set; }
        public List<int> Accounts { get; set; }
        public List<decimal> TotalCapital { get; set; }
        public List<string> CountryList { get; set; }
        public string Countries { get; set; }

        public void OnGet()
        {
            Customers = new List<int>
            {
              _countryService.GetCustomerCount("Sweden"),
              _countryService.GetCustomerCount("Norway"),
              _countryService.GetCustomerCount("Finland"),
              _countryService.GetCustomerCount("Denmark")
             };
            Accounts = new List<int>
            {
              _countryService.GetAccountCount("Sweden"),
              _countryService.GetAccountCount("Norway"),
              _countryService.GetAccountCount("Finland"),
              _countryService.GetAccountCount("Denmark")
            };
            TotalCapital = new List<decimal>
            {
              _countryService.GetTotalCapital("Sweden"),
              _countryService.GetTotalCapital("Norway"),
              _countryService.GetTotalCapital("Finland"),
              _countryService.GetTotalCapital("Denmark")
            };

            CountryList = new List<string>() { "Sweden", "Norway", "Finland", "Denmark" };
        }

    }
}
