using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class RecettesIngredients
    {
        public int IngredientId { get; set; }
        public int RecetteId { get; set; }
        public virtual Ingredients Ingredient { get; set; }
        public virtual Recettes Recette { get; set; }
    }
}
