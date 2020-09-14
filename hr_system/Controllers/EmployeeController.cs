using hr_system.Attributes;
using hr_system.Models;
using hr_system.Repository;
using hr_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hr_system.Controllers
{
    [OAuthAuthorize]
    [RoutePrefix("api")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]string ssn)
        {
            var employee = _employeeService.GetBySSN(ssn);
            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPatch]
        public IHttpActionResult Update(EditEmployeeViewModel model, [FromUri]int id)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Employee Data");
            
            var emp = _employeeService.GetById(id);
            if (emp == null) return NotFound();

            emp.Address = model.Address;
            emp.FirstName = model.FirstName;
            emp.LastName = model.LastName;
            emp.EmployeeRoleId = model.RoleId;
            emp.DateOfBirth = model.DateOfBirth;

            var updatedEmp = _employeeService.Edit(emp);

            return Ok(updatedEmp);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var emp = _employeeService.GetById(id);
            if (emp == null) return NotFound();

            _employeeService.Delete(emp);
            return Ok();
        }
    }
}
