using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ui_Layer.Models
{
    public class OrderHView
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public DateTime Add_date { get; set; }
        public string Order_Discripton { get; set; }
        [Required]
        public float Total { get; set; }
        public string Cust_Id { get; set; }
        public CustomerView Customer { get; set; }
        public IEnumerable<OrderDView> OrderD { get; set; }

    }
}
