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

        //public ActionResult Update(uint Id)
        //{
        //    var customer = Customer.CustomerViewModels.SingleOrDefault(c => c.Id = Id);
        //    var viewModel = new CustomerViewModel
        //    {
        //        Id = Id;

                    
        //    };
                                   
        //    return View("SignUp", "viewModel");
        //}

      
        private ActionResult HttpNotFound()
        {
           throw new NotImplementedException();
        }
    }
}



























