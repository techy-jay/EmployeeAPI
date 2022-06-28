using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    [Keyless]
    public partial class Response
    {

        public int status { get; set; }

        public string message { get; set; }

        public object data { get; set; }

    }
}
