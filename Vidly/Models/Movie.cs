﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public static class Movie
    {
        public static List<MovieViewModel> MovieViewModel { get; set; }
        public static MovieViewModel MovieToUpdate { get; set; }

    }
}
