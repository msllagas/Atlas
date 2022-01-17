using System.ComponentModel.DataAnnotations;

namespace Atlas
{
    public class CSDelivery
    {
        [Key]
        public int TrackingNumber{ get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Amount { get; set; }
    }
}