using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseDataAcess;
using EnterpriseDomain;

namespace EnterpriseBusiness
{
    public class EmployeeBusiness
    {
        public List<Employee> GetEmployees()
        {
            DataAcess<Employee> DATA = new DataAcess<Employee>();
            List<Employee> employees = DATA.GetAll("Select * from Employee");
            return employees;
        }
    }
}
