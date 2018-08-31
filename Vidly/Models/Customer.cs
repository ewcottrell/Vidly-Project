using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(25)]
        public string Birthdate { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }





        /* Finish this method later
        public bool IsSubscribed(Customer customer)
        {
            return "#"
        }
        */
    }
}
























