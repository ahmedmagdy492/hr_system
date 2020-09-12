using hr_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class LoginService : ILoginService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPasswordHasher _passwordHasher;

        public LoginService(
            IEmployeeService employeeService,
            IPasswordHasher passwordHasher
            )
        {
            _employeeService = employeeService;
            _passwordHasher = passwordHasher;
        }

        public bool CanLogin(string username, string password)
        {
            string passHash = _passwordHasher.Hash(password);
            var employees = _employeeService.GetAll().ToList();

            var employee = employees.FirstOrDefault(e => e.Username == username && e.HashedPassword == passHash);

            return employee == null ? false : true;
        }
    }
}