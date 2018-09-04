using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Vidly
{
    public class Repsitory
    {
        public static string ConnectionString;

        public Repsitory(string connectionstring)
        {
            ConnectionString = connectionstring;
        }
    }
}
