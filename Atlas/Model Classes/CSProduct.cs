using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{
    public class CSProduct
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public float Price { get; set; }

        public string Measurement { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Stocks { get; set; }
        
    }
}
