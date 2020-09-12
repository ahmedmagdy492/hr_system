using hr_system.Data;
using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class PhoneService : IPhoneNumberService
    {
        private readonly HrDbModel _context;

        public PhoneService(HrDbModel context)
        {
            _context = context;
        }
        public void AddPhoneNumber(int employeeId, string phoneNumber)
        {
            var phone = new PhoneNumber
            {
                Employee_id = employeeId,
                Number = phoneNumber
            };
            _context.PhoneNumbers.Add(phone);
            _context.SaveChanges();
        }
    }
}