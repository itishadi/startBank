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
    [Authorize(Roles = "Cashier")]
    public class CreateModel : PageModel
    {

        private readonly BankAppDataContext _dbContext;

        public CreateModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public CustomerModel CreateUserRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var userDbModel = new Customer
            {
                NationalId = CreateUserRequest.NationalID,
                Givenname = CreateUserRequest.Name,
                Surname = CreateUserRequest.LastName,
                Streetaddress = CreateUserRequest.Address,
                Birthday = CreateUserRequest.Birth,
                Telephonenumber = CreateUserRequest.Phone,
                Emailaddress = CreateUserRequest.Email,
                Gender = CreateUserRequest.Gender,
                Country = CreateUserRequest.Country,
                City = CreateUserRequest.City,
                CountryCode = CreateUserRequest.CountryCode,
                Telephonecountrycode = CreateUserRequest.Telephonecountrycode,
                Zipcode = CreateUserRequest.Zipcode
            };

            _dbContext.Customers.Add(userDbModel);
            _dbContext.SaveChanges();

            ViewData["Message"] = "Employee created successfully!";

        }

    }

}
