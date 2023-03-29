    using startBank.BankAppDatas;
using static startBank.Pages.CustomerModel;

namespace startBank.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BankAppDataContext _dbContext;

        public CustomerService(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CustomerViewModel> GetCustomers(string sortColumn, string sortOrder)
        {

            var query = _dbContext.Customers.AsQueryable();

            if (sortColumn == "Name")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Givenname);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Givenname);

            if (sortColumn == "Adress")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Streetaddress);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Streetaddress);

            if (sortColumn == "City")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.City);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.City);

            var Customers = query.Select(s => new CustomerViewModel
            {
                // kundnummer och personnummer, namn, adress, city 
                Id = s.CustomerId,
                NationalID = s.NationalId,
                Name = s.Givenname,
                Adress = s.Streetaddress,
                City = s.City
            }).ToList();

            return Customers;
        }
    }
}
