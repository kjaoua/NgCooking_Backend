using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class Comments
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        public int userId { get; set; }
        [Required]
        public string Comment { get; set; }
        [ForeignKey("userId")]
        public  Communaute User { get; set; }
        
        [Required]
        public int Mark { get; set; }

    }
}
