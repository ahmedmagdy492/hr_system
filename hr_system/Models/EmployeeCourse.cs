namespace hr_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeCourses")]
    public partial class EmployeeCourse
    {
        public int Id { get; set; }

        public float Mark { get; set; }

        public int CourseId { get; set; }

        public int EmployeeId { get; set; }

        public virtual Course Cours { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
