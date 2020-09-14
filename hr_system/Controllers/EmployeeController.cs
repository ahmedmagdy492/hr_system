using hr_system.Attributes;
using hr_system.Repository;
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
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
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
    }
}
