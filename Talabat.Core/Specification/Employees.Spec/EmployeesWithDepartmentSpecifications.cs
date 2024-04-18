using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification.Employees.Spec
{
    public class EmployeesWithDepartmentSpecifications : BaseSpecifications<Employee>
    {
        public EmployeesWithDepartmentSpecifications() :base()
        {
            Includes.Add(E =>  E.Department);
        }

        public EmployeesWithDepartmentSpecifications(int id) : base (E => E.Id == id)
        {
            Includes.Add(E => E.Department);
        }
    }
}
