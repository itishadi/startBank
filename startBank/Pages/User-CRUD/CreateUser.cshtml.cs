using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace startBank.Pages.User_CRUD
{
    [Authorize(Roles = "Admin")]
    public class CreateUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
