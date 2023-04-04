using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using startBank.BankAppDatas;
using startBank.Models;
using startBank.Services;

namespace startBank.Pages
{
    public class CustomerViewModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //public class CustomerViewModel
        //{
        //    public int Id { get; set; }
        //    public string NationalID { get; set; }
        //    public string Name { get; set; }
        //    public string Address { get; set; }
        //    public string City { get; set; }
        //}
        public List<CustomerModel> Customers { get; set; }
        public int OneCustomerId { get; set; }
        public int CurrentPage { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Q { get; set; }

        public void OnGet(int oneCustomerId, string sortColumn, string sortOrder, int p, string q) 
        {
            Q = q;
            SortColumn = sortColumn;
            SortOrder = sortOrder;

            if (p == 0)
                p = 1;
            CurrentPage = p;

            OneCustomerId = oneCustomerId;
            Customers = _customerService.GetCustomers(oneCustomerId, sortColumn, sortOrder, p, q);


        }
    }
    }
