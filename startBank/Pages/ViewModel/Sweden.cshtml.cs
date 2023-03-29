using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;

namespace startBank.Pages.ViewModel
{
    public class SwedenModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;

        public SwedenModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public List<SwedenModel> RichestPeople { get; set; }

        public void OnGet()
        {
            // Anslut till databasen
            using (var db = new BankAppDataContext())
            {
                // Hämta de 10 rikaste personerna i Sverige från databasen
               var  RichestPeople = _dbContext.Customers
                    .Where(c => c.Country == "Sweden")
                    .OrderByDescending(c => c.Givenname)
                    .Take(10)
                    .ToList();

              
            }

        }
    }
}
