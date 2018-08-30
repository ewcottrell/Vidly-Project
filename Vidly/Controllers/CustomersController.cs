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

        public ActionResult Signup()
        {
            return View();

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



























