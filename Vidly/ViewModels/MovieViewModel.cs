using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int NumberInStock { get; set; }
    }
}
