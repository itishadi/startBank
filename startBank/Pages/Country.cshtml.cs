using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages
{
    public class Country : PageModel
    {

        private readonly ICountryService _countryService;

        public Country(ICountryService countryService)
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
              _countryService.GetCustomerCount("Denmark"),
              _countryService.GetCustomerCount("Finland")
             };
            Accounts = new List<int>
            {
              _countryService.GetAccountCount("Sweden"),
              _countryService.GetAccountCount("Norway"),
              _countryService.GetAccountCount("Denmark"),
              _countryService.GetAccountCount("Finland")
            };
            TotalCapital = new List<decimal>
            {
              _countryService.GetTotalCapital("Sweden"),
              _countryService.GetTotalCapital("Norway"),
              _countryService.GetTotalCapital("Denmark"),
              _countryService.GetTotalCapital("Finland")
            };

            CountryList = new List<string>() { "Sweden", "Norway", "Denmark", "Finland" };
        }
    }
}

