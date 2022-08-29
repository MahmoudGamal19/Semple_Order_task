using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doman.Model
{
   public class OrderH:EntitiyBase
    {
        [Required]
        public DateTime Add_date { get; set; }
        public string Order_Discripton { get; set; }
        [Required]
        public float Total { get; set; }
        public string Cust_Id { get; set; }
        public Customer Customer { get; set; }
        public ICollection< OrderD >OrderD { get; set; }

    }
}
