using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Customer
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer c);
        void AddCust(CustomerOrder c);
        bool IsValid(string _username, string _password);
        Customer GetCustomerByID(int CustomerID);
    }
}
