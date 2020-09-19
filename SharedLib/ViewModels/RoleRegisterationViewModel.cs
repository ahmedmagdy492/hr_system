using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharedLib.ViewModels
{
    public class RoleRegisterationViewModel
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int HolydaysCount { get; set; }
    }
}