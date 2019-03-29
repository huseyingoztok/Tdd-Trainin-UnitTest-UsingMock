using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business.Tests
{
    [TestClass]
    public class CustomerManagerTests
    {
        Mock<ICustomerDal> _mockCustomerDal;
        List<Customer> customers;
        [TestInitialize]
        public void Start()
        {
            _mockCustomerDal = new Mock<ICustomerDal>();
            customers = new List<Customer>
            {
                new Customer { Id =1, FirstName="Ali"},
                new Customer { Id =2, FirstName="Ahmet"},
                new Customer { Id =3, FirstName="Ayşe"},
                new Customer { Id =4, FirstName="Arda"},
                new Customer { Id =5, FirstName="Burhan"},
            };
            _mockCustomerDal.Setup(m => m.GetAll()).Returns(customers);
        }
        [TestMethod]
        public void All_customers_listable()
        {
            //Arrange (Test için gerekli ortamın oluşturulması)
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);
            //Act (Aksiyon alınan kısım)
            List<Customer> customers = customerService.GetAll();

            //Assert (Tahmin edlin beklenilen sonuç)
            //Assert.AreEqual(4, customers.Count); //Message: Assert.AreEqual failed. Expected:<4>. Actual:<5>. 
            Assert.AreEqual(5, customers.Count);
        }

        [TestMethod]
        public void Name_initial_A_all_customers()
        {
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);

            List<Customer> customers = customerService.GetCustomerInitialA("A");

            Assert.AreEqual(4, customers.Count);
        }

        [TestMethod]
        public void Name_initial_a_all_customers()
        {
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);

            List<Customer> customers = customerService.GetCustomerInitialA("a");

            Assert.AreEqual(4, customers.Count);
        }
    }

}

//Müşteriler listelenebilmelidir.
//Müşteriler baş harflerine göre sıralanabilmelidir.
    //Test case
    //5 elemanlı bir listem olsun