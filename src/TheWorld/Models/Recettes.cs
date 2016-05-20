using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class Recettes
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string nameToDisplay { get; set; }
        
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Communaute Creator { get; set; }
        [Required]
        public bool isAvailable { get; set; }
        [Required]
        public string  picture { get; set; }
        [Required]
        public string preparation { get; set; }
       
        public ICollection<Comments> Comments { get; set; }
        public virtual ICollection<RecettesIngredients> RecettesIngredients { get; set; }
        public Recettes()
        {
            RecettesIngredients = new HashSet<RecettesIngredients>();
            Comments = new HashSet<Comments>();

        }
    }
}
