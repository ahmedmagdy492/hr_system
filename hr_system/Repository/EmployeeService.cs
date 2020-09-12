using hr_system.Data;
using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HrDbModel _context;

        public EmployeeService(HrDbModel context)
        {
            _context = context;
        }

        public Employee Add(Employee employee)
        {
            var created = _context.Employees.Add(employee);
            _context.SaveChanges();
            return created;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}