using System.ComponentModel.DataAnnotations;

namespace Ui_Layer.Models
{
    public class OrderDView
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int Count { get; set; }
        public string Orderh_Id;
        public string Item_Name;

        public string Item_Id { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float Total { get; set; }

    }
}
