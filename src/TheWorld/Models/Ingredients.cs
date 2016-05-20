using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class Ingredients
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string Name { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public Categories Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<RecettesIngredients> RecettesIngredients { get; set; }
        public Ingredients()
        {
            RecettesIngredients = new HashSet<RecettesIngredients>();
        }

    }
}
