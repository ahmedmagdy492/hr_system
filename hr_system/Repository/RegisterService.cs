using hr_system.Models;
using hr_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class RegisterService : IRegisterService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmployeeService _employeeService;
        private readonly IPhoneNumberService _phoneNumberService;

        public RegisterService(
            IPasswordHasher passwordHasher,
            IEmployeeService employeeService,
            IPhoneNumberService phoneNumberService
            )
        {
            _passwordHasher = passwordHasher;
            _employeeService = employeeService;
            this._phoneNumberService = phoneNumberService;
        }
        public bool CanRegister(RegisterViewModel model)
        {
            var employees = _employeeService.GetAll();
            var employee = employees.FirstOrDefault(e => e.Username == model.UserName);
            employee = employees.FirstOrDefault(e => e.SSN == model.SSN);
            return employee == null ? true : false;
        }

        public bool Register(RegisterViewModel model)
        {
            var result = CanRegister(model);
            if(result)
            {
                var employee = new Employee
                {
                    SSN = model.SSN,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HashedPassword = _passwordHasher.Hash(model.Password),
                    Address = model.Address,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.EmailAddress,
                    Username = model.UserName,
                    EmployeeRoleId = model.RoleId
                };
                var createdEmp = _employeeService.Add(employee);
                
                foreach(var phoneNumber in model.PhoneNumbers)
                {
                    _phoneNumberService.AddPhoneNumber(createdEmp.Id, phoneNumber);
                }

                return true;
            }
            return false;
        }
    }
}