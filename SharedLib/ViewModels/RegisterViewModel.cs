using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharedLib.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string SSN { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Compare(nameof(EmailAddress))]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^[0-9A-Za-z]{8,20}$")]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
    }
}