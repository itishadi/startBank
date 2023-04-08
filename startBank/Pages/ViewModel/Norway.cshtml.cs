using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages.ViewModel
{
    public class NorwayModel : PageModel
    {
        private readonly ICountryService _countryService;

        public NorwayModel(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public List<CustomerModel> TopTenNorway { get; set; }

        public void OnGet()
        {
            string[] countries = { "Norway" };
            List<List<CustomerModel>> top10Customers = new List<List<CustomerModel>>();
            foreach (string country in countries)
            {
                top10Customers.Add(_countryService.GetTopCustomers(country));
            }
            TopTenNorway = top10Customers[0];
        }
    }
}
