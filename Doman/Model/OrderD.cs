using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doman.Model
{
    public class OrderD:EntitiyBase
    {
        [Required]
        public int Count { get; set; }
        public string Orderh_Id { get; set; }
        public string Item_Name { get; set; }
        public  OrderH  OrderH { get; set; }
      
        public string Item_Id { get; set; }
        public  Items Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float Total { get; set; }
    }
}
