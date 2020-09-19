namespace SharedLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Course
    {
        public Course()
        {
            EmployeeCourses = new HashSet<EmployeeCourse>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Duration { get; set; }

        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; }
    }
}
