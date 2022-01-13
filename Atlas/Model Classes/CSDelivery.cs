using System.ComponentModel.DataAnnotations;

namespace Atlas
{
    public class CSDelivery
    {
        [Key]
        public int TrackingNumber{ get; set; }

        public int Quantity { get; set; }

        public float Amount { get; set; }

    }
}