using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages.ViewModel
{
    public class DenmarkModel : PageModel
    {
        private readonly ICountryService _countryService;
        public DenmarkModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenDenmark { get; set; }
        public void OnGet()
        {
            string[] countries = { "Denmark" };
            List<List<CustomerModel>> top10Customers = new List<List<CustomerModel>>();
            foreach (string country in countries)
            {
                top10Customers.Add(_countryService.GetTopCustomers(country));
            }
            TopTenDenmark = top10Customers[0];
        }
    }
}
