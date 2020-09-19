namespace SharedLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        public Employee()
        {
            Documents = new HashSet<Document>();
            EmployeeCourses = new HashSet<EmployeeCourse>();
            Holidays = new HashSet<Holiday>();
            PhoneNumbers = new HashSet<PhoneNumber>();
        }

        public int Id { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int EmployeeRoleId { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; }

        public virtual ICollection<Holiday> Holidays { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
