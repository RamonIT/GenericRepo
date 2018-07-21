using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnterpriseBusiness;
using EnterpriseDomain;

namespace EnterpriseServices.Controllers
{
    //[Authorize]
    public class EmployeesController : ApiController
    {
        // GET api/Employees
        public IEnumerable<Employee> Get()
        {
            EmployeeBusiness EB = new EmployeeBusiness();
            return EB.GetEmployees();
        }

        // GET api/Employees/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Employees
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Employees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Employees/5
        public void Delete(int id)
        {
        }
    }
}
