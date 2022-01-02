using System.ComponentModel.DataAnnotations;

namespace Atlas
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
    }
}