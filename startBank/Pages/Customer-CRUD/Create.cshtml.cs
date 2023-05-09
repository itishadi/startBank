using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using startBank.BankAppDatas;
using startBank.Data;
using startBank.Models;
using System.Data;

namespace startBank.Pages.Customer_CRUD
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {

        private readonly BankAppDataContext _dbContext;
        private readonly IMapper _mapper;

        public CreateModel(BankAppDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [BindProperty]
        public CustomerModel CreateUserRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var userDbModel = new Customer();
            _mapper.Map(CreateUserRequest, userDbModel);

            _dbContext.Customers.Add(userDbModel);
            _dbContext.SaveChanges();

            ViewData["Message"] = "Employee created successfully!";

        }

    }

}
