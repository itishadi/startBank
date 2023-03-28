using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;

namespace startBank.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;

        public CustomerModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class CustomerViewModel
        {
            public int Id { get; set; }
            public string NationalID { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
            public string City { get; set; }
        }

        public List<CustomerViewModel> Customers { get; set; } = new List<CustomerViewModel>();

        public void OnGet() 
        {
            Customers = _dbContext.Customers.Select(s => new CustomerViewModel
            {
                // kundnummer och personnummer, namn, adress, city 
                Id = s.CustomerId,
                NationalID = s.NationalId,
                Name = s.Givenname,
                Adress = s.Streetaddress,
                City = s.City
            }).ToList();
        }
    }
}
