using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages
{
    [BindProperties]
    public class OneCustomerModel : PageModel
    {

        private readonly ICustomerService _customerService;
        public OneCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public CustomerModel OneCustomerDetail { get; set; }


        public void OnGet(int id)
        {
            OneCustomerDetail = _customerService.GetCustomer(id);

        }
    }
}
