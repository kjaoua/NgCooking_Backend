using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class Categories
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string nameToDisplay{ get; set; }
        //public virtual ICollection<Ingredients> Ingredients { get; set; }
        

    }
}
