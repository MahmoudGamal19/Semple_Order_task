using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ui_Layer.Models.RegisterModel
{
    public class RegisterView
    {
        [Required]
        public string Neme { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [StringLength(11, ErrorMessage = "It's Not Phone Number ")]
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Matched ")]
        [Display(Name = "Conferm Pass")]
        public string Conferm_Password { get; set; }
    }

}

