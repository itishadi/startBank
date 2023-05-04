using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using startBank.BankAppDatas;
using startBank.Models;

namespace startBank.Services
{
    public interface ICustomerService
    {
      List<CustomerModel> GetCustomers(int oneCustomerId, string sortColumn, string sortOrder, int p, string q);

        CustomerModel GetCustomer(int customerId);

    }

}
