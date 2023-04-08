//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using startBank.Models;
//using startBank.Services;

//namespace startBank.Pages
//{
//    public class Country : PageModel
//    {
//        private readonly ICountryService _countryService;

//        public Country(ICountryService countryService)
//        {
//            _countryService = countryService;
//        }
      
//        public void OnGet()
//        {
//            string[] countries = { "Sweden", "Norway", "Denmark", "Finland" };
//            List<List<CustomerModel>> top10Customers = new List<List<CustomerModel>>();
//            foreach (string country in countries)
//            {
//                top10Customers.Add(_countryService.GetTopCustomers(country));
//            }
//            TopTenSweden = top10Customers[0];
//            TopTenNorway = top10Customers[1];
//            TopTenDenmark = top10Customers[2];
//            TopTenFinland = top10Customers[3];
//        }

//        public List<CustomerModel> TopTenSweden { get; set; }
//        public List<CustomerModel> TopTenNorway { get; set; }
//        public List<CustomerModel> TopTenDenmark { get; set; }
//        public List<CustomerModel> TopTenFinland { get; set; }

//    }
//}

