using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_system.Repository
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetBySSN(string ssn);
        Employee GetById(int id);
        Employee Add(Employee employee);
        void Delete(Employee employee);
        Employee Edit(Employee emp);
    }
}
