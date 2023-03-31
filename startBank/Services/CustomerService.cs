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
        public List<CustomerViewModel> GetCustomers(
            int oneCustomerId, string sortColumn, string sortOrder, int p, string q)
        {

            var query = _dbContext.Customers
               .Where(p => p.Givenname == oneCustomerId.ToString());
            query = _dbContext.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query
                    .Where(p => p.Givenname.Contains(q) ||
                    p.Country.Contains(q) ||
                    p.City.Contains(q) ||
                    p.Gender.Contains(q) ||
                    p.NationalId.Contains(q) ||
                    p.Streetaddress.Contains(q) ||
                    p.Telephonenumber.Contains(q) ||
                    p.Telephonecountrycode.Contains(q) ||
                    p.Surname.Contains(q) ||
                    p.Emailaddress.Contains(q) ||
                    p.Zipcode.Contains(q) ||
                    p.CustomerId.ToString().Contains(q));
            }


            if (sortColumn == "NationalID")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.NationalId);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.NationalId);

            if (sortColumn == "Name")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Givenname);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Givenname);

            if (sortColumn == "Address")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.Streetaddress);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.Streetaddress);

            if (sortColumn == "City")
                if (sortOrder == "asc")
                    query = query.OrderBy(s => s.City);
                else if (sortOrder == "desc")
                    query = query.OrderByDescending(s => s.City);


            var itemIndex = (p - 1) * 5; // 5 är page storlek

            query = query.Skip(itemIndex);
            query = query.Take(5); // 5 är page storlek
            var Customers = query.Select(s => new CustomerViewModel
            {
                // kundnummer och personnummer, namn, adress, city 
                Id = s.CustomerId,
                NationalID = s.NationalId,
                Name = s.Givenname,
                Address = s.Streetaddress,
                City = s.City
            }).ToList();


            return Customers;
        }
    }
}
