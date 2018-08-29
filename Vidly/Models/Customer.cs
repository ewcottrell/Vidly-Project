using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }//come back and delete this when you get db connected
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }




        /* Finish this method later
        public bool IsSubscribed(Customer customer)
        {
            return "#"
        }
        */
    }
}
























