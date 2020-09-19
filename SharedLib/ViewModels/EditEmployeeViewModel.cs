using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharedLib.ViewModels
{
    public class EditEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int RoleId { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public List<string> PhoneNumbers { get; set; } = new List<string>();
    }
}