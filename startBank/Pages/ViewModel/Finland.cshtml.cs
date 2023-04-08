using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages.ViewModel
{
    public class FinlandModel : PageModel
    {
        private readonly ICountryService _countryService;

        public FinlandModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenFinland { get; set; }

        public void OnGet()
        {
            string[] countries = { "Finland" };
            List<List<CustomerModel>> top10Customers = new List<List<CustomerModel>>();
            foreach (string country in countries)
            {
                top10Customers.Add(_countryService.GetTopCustomers(country));
            }
            TopTenFinland = top10Customers[0];
        }
    }
}
