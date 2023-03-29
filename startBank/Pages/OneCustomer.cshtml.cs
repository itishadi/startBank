using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;

namespace startBank.Pages
{
    public class OneCustomerModel : PageModel
    {

        private readonly BankAppDataContext _dbContext;
        public string NationalID { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }



        public OneCustomerModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
            NationalID = _dbContext.Customers.First(s => s.CustomerId == id).NationalId;
            CustomerName = _dbContext.Customers.First(s => s.CustomerId == id).Givenname;
            Adress = _dbContext.Customers.First(s => s.CustomerId == id).Streetaddress;
            City = _dbContext.Customers.First(s => s.CustomerId == id).City;

        }
    }
}
