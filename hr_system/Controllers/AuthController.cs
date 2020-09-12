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
    [RoutePrefix("api")]
    public class AuthController : ApiController
    {
        private readonly IRegisterService _registerService;

        public AuthController(
            IRegisterService registerService
            )
        {
            this._registerService = registerService;
        }

        [AllowAnonymous]
        [Route("auth/register")]
        [HttpPost]
        public IHttpActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Registeration Data");

            var result = _registerService.Register(model);

            if (result) return Ok();
            return BadRequest("An Error has occured");
        }
    }
}
