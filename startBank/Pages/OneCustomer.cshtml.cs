using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;

namespace startBank.Pages
{
    public class OneCustomerModel : PageModel
    {

        private readonly BankAppDataContext _dbContext;
        public string CustomerNId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }



        public OneCustomerModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
            CustomerNId = _dbContext.Customers.First(s => s.CustomerId == id).NationalId;
            CustomerName = _dbContext.Customers.First(s => s.CustomerId == id).Givenname;
            CustomerCity = _dbContext.Customers.First(s => s.CustomerId == id).City;
            CustomerCountry = _dbContext.Customers.First(s => s.CustomerId == id).Country;

        }
    }
}
