using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ui_Layer.Models
{
    public class CustomerView
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime Date { get; set; }
        public int PhoneNo { get; set; }
    }
}
