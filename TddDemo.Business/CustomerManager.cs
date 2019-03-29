using System.Collections.Generic;
using System.Linq;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            //Business codes
            return _customerDal.GetAll();
        }

        public List<Customer> GetCustomerInitialA(string v)
        {
            return _customerDal.GetAll().Where(x => x.FirstName.ToLower().StartsWith(v.ToLower())).ToList();
        }
    }
}