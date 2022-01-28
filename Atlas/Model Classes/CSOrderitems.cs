using Atlas.Model_Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atlas.Model_Classes
{
    public class CSOrderitems
    {
        [Key]
        public int TrackingNumber { get; set; }

        [Key]
        public int ProductID { get; set; }



        public int Quantity { get; set; }

        public float UnitPrice { get; set; }
        public float TotPrice { get; set; }



    }
}
