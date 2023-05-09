using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace startBank.Pages.Customer_CRUD
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
