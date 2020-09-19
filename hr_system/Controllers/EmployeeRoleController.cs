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
    //[OAuthAuthorize]
    [RoutePrefix("api")]
    public class EmployeeRoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public EmployeeRoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpPost]
        public IHttpActionResult Add(RoleRegisterationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid role data");

            _roleService.Add(new EmployeeRole
            {
                RoleName = model.RoleName,
                Salary = model.Salary,
                Legal_Holiday_count = model.HolydaysCount
            });
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_roleService.GetAll().ToList());
        }
    }
}
