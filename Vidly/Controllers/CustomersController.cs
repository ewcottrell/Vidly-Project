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
            Customer.CustomerViewModels = customerRepository.GetCustomers();
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Add(string firstname, string lastname, string birthdate, string email, string phonenumber)
        {
            CustomerViewModel customer = new CustomerViewModel() { FirstName = firstname, LastName = lastname, Birthdate = birthdate, Email = email, PhoneNumber = phonenumber };
            customerRepository.AddCustomer(customer);
            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Delete(uint Id)
        {
            customerRepository.DeleteCustomer(Id);
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(uint Id)
        {
            return View();
        }

        public ActionResult Update(uint id)
        {
            foreach (CustomerViewModel customer in Customer.CustomerViewModels)
            {
                if (customer.Id == id)
                {
                    Customer.Cust = customer;
                }
            }
             return View();
        }

        public ActionResult UpdateCustomer(string firstname, string lastname, string birthdate, string email, string phonenumber)
        {
            CustomerViewModel customer = new CustomerViewModel() { FirstName = firstname, LastName = lastname, Birthdate = birthdate, Email = email, PhoneNumber = phonenumber };
            customerRepository.UpdateCustomer(customer);
            return RedirectToAction("Index", "Customers");
        }

      
        private ActionResult HttpNotFound()
        {
           throw new NotImplementedException();
        }
    }
}



























