using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doman.Model
{
    public class Items:EntitiyBase
    {
        [Required]
        public string Discripton { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }

        public List<OrderD> OrderDs { get; set; }
       

    }
}
