using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{
    [Keyless]
    public class ProductNameGet
    {
        public string ProductName { get; set; }
    }
}
