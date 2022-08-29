using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doman.Model
{
    public class Customer:EntitiyBase
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime Date { get; set; }
        public int PhoneNo { get; set; }
       public List<OrderH> orderHs { get; set; }
    }
}
