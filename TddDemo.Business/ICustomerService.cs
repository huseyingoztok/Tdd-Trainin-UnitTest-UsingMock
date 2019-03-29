using System.Collections.Generic;
using TddDemo.Entities;

namespace TddDemo.Business
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        List<Customer> GetCustomerInitialA(string v);
    }
}