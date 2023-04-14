using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages.ViewModel
{
    public class SwedenModel : PageModel
    {
        private readonly ICountryService _countryService;

        public SwedenModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenSweden { get; set; }

        public void OnGet()
        {
            string[] countries = { "Sweden" };
            List<List<CustomerModel>> top10Customers = new List<List<CustomerModel>>();
            foreach (string country in countries)
            {
                top10Customers.Add(_countryService.GetTopCustomers(country));
            }
            TopTenSweden = top10Customers[0];

        }

     
    }
}
