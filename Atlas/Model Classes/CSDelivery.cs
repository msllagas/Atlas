using Atlas.Model_Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atlas
{
    public class CSDelivery
    {
        [Key]
        public int TrackingNumber{ get; set; }

        public CSCustomer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public string OrderDate { get; set; }
    }
}