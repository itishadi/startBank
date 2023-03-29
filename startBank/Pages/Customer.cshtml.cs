using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;
using startBank.Services;

namespace startBank.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public class CustomerViewModel
        {
            public int Id { get; set; }
            public string NationalID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
        }

        public List<CustomerViewModel> Customers { get; set; }

        public void OnGet(string sortColumn, string sortOrder) 
        {
            //    Customers = _customerService.GetCustomers.Select(s => new CustomerViewModel
            //    {
            //        // kundnummer och personnummer, namn, adress, city 
            //        Id = s.CustomerId,
            //        NationalID = s.NationalId,
            //        Name = s.Givenname,
            //        Adress = s.Streetaddress,
            //        City = s.City
            //    }).ToList();
            //}
            Customers = _customerService.GetCustomers(sortColumn, sortOrder);


        }
    }
    }
