using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr_system.Repository
{
    public interface IRoleService
    {
        EmployeeRole Add(EmployeeRole role);
        IEnumerable<EmployeeRole> GetAll();
    }
}
