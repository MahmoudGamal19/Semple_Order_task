using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ui_Layer.Models.RegisterModel
{
    public class LoginView
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remeber Me ?")]
        public bool Remeber_Me { get; set; }
    }
}
