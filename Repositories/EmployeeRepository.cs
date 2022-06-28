using Dapper;
using Employee.Interface;
using Employee.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace Employee.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployee
    {
        public EmployeeRepository(IConfiguration configuration) :base(configuration)
        { 
        }
        public Response GetEmployee()
        {
            try {
                DynamicParameters dynamicParameter = new DynamicParameters();
                DataTable dt = GetDataTable("EMS_GetEmployee", dynamicParameter);
                List<EMS_GetEmployee> getemployee = Get_dataTable_to_json<List<EMS_GetEmployee>>(dt);
                Response res = GetResponse(getemployee);
                //Response res = new Response();
                //res.status = 1;
                //res.message = "Done";
                //res.data = getemployee;
                return res;
            }
            catch (Exception e) {
                return GetError(e.Message.ToString());
            }
        }
    }
}
