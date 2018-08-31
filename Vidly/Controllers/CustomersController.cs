using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerRepository customerRepository;
        public CustomersController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Signup(string firstname, string lastname, string birthdate, string email, string phonenumber)
        {
            var repository = new CustomerRepository();
            Customer customer = new Customer() { FirstName = firstname, LastName = lastname, Birthdate = birthdate, Email = email, PhoneNumber = phonenumber };
            repository.AddCustomer(customer);
            return Content("Customer added successfully!");

        }
        //public ActionResult Add(string firstname, string lastname, string dob, string phonenumber, string email)
        //{
            
        //    var repo = new CustomerRepository();
        //    Customer customer = new Customer() {FirstName = firstname, LastName = lastname, Birthdate = }
        //    return View();
        //}
        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    
    }
}



























