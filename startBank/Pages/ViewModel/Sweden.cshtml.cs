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


        public void OnGet()
        {
        }
    }
}
