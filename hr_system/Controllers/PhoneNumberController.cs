using hr_system.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hr_system.Controllers
{
    [RoutePrefix("api")]
    public class PhoneNumberController : ApiController
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumberController(IPhoneNumberService phoneNumberService)
        {
            this._phoneNumberService = phoneNumberService;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int phoneNumberId)
        {
            var phoneNumber = _phoneNumberService.GetById(phoneNumberId);
            if (phoneNumber == null) return NotFound();

            _phoneNumberService.DeletePhoneNumber(phoneNumber);
            return Ok();
        }
    }
}
