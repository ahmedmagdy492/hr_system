using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hr_system.ViewModels
{
    public class AddCourseViewModel
    {
        [Required]
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
    }
}