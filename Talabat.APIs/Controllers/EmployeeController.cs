using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contruct;
using Talabat.Core.Specification.Employees.Spec;

namespace Talabat.APIs.Controllers
{
    public class EmployeeController : BaseAPIController
    {
        private readonly IGenaricRepository<Employee> _GenaricRepo;

        public EmployeeController(IGenaricRepository<Employee> GenaricRepo)
        {
            _GenaricRepo = GenaricRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var Spec = new EmployeesWithDepartmentSpecifications();
            var employees = _GenaricRepo.GetAllWithSpecAsync(Spec);

            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeById(int id)
        {
            var Spec = new EmployeesWithDepartmentSpecifications(id);
            var employee = _GenaricRepo.GetWithSpecAsync(id,Spec);

            if (employee is null)
                return NotFound(new { StatusCode = 404, Message = "Not Found" }); // 404

            return Ok(employee);
        }
    }
}
