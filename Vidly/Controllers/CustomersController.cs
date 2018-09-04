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
            customerRepository.GetCustomers();
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = customerRepository.GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Signup()
        {
            return View();    
        }

        public ActionResult Add(string firstname, string lastname, string birthdate, string email, string phonenumber)
        {
            Customer customer = new Customer() { FirstName = firstname, LastName = lastname, Birthdate = birthdate, Email = email, PhoneNumber = phonenumber };
            customerRepository.AddCustomer(customer);
            return RedirectToAction("Index", "Customers");

        }
       
        private ActionResult HttpNotFound()
        {
           throw new NotImplementedException();
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, FirstName = "John Smith" },
                new Customer { Id = 2, FirstName = "Mary Williams" }
            };
       }
    }
}



























