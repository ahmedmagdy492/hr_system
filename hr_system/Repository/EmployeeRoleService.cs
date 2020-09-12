using hr_system.Data;
using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class EmployeeRoleService : IRoleService
    {
        private readonly HrDbModel _context;

        public EmployeeRoleService(HrDbModel context)
        {
            this._context = context;
        }

        private bool IsExist(string roleName)
        {
            var role = _context.EmployeeRoles.FirstOrDefault(r => r.RoleName == roleName);
            return role == null ? false : true;
        }

        public EmployeeRole Add(EmployeeRole role)
        {
            if(!IsExist(role.RoleName))
            {
                var createdRole = _context.EmployeeRoles.Add(role);
                return createdRole;
            }
            return null;
        }

        public IEnumerable<EmployeeRole> GetAll()
        {
            return _context.EmployeeRoles;
        }
    }
}