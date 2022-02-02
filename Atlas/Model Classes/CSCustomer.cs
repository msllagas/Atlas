using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{
    public class CSCustomer
    {
        [Key]
        public int ID{ get; set; }

        [Required]
        public string CustomerName{ get; set; }

        [Required]
        public string Address{ get; set; }

        [Required]
        public string ContactNumber { get; set; }
    }
}
