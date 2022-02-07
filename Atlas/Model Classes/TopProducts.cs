using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Atlas.Model_Classes
{   
    [Keyless]
    public class TopProducts
    {      
        public string ProductName { get; set; }
        public float TotalSold { get; set; }
        public float TotalQuantity { get; set; }
    }
}
