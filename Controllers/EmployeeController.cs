using Employee.Interface;
using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IEmployee iemployee;

        public EmployeeController(IEmployee _employee)
        {
            iemployee = _employee;
        }

        [HttpGet("GetEmployeeUsingSP")]
        public Response GetEmployeeUsingSP() {
            return iemployee.GetEmployee();
        }

    }
}
