namespace SharedLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string RoleName { get; set; }

        public decimal Salary { get; set; }

        public int Legal_Holiday_count { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
