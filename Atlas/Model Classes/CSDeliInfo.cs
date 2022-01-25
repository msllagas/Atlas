using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{
    class CSDeliInfo
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity{ get; set; }
        public float Amount { get; set; }
    }
}
