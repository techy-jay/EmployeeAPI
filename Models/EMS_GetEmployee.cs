using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    [Keyless]
    public partial class EMS_GetEmployee
    {
        public string EmployeeName { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }
    }
}
