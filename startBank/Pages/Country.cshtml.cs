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

        public void OnGet()
        {
        
        }

     

    }
}

