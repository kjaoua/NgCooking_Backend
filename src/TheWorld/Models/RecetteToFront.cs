using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class RecetteToFront
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string id { get; set; }

        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Communaute Creator { get; set; }
        [Required]
        public bool isAvailable { get; set; }
        [Required]
        public string picture { get; set; }
        [Required]
        public string preparation { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public virtual ICollection<string> Ingredients { get; set; }
        public RecetteToFront()
        {
            Ingredients = new HashSet<string>();
            Comments = new HashSet<Comments>();

        }
        
    }

    //public class IngredientsToFront
    //{
    //    public string Name { get; set; }
    //    [Required]
    //    public bool IsAvailable { get; set; }
    //    [Required]
    //    public string Picture { get; set; }
    //    [Required]
    //    public int Calories { get; set; }
    //    [Required]
    //    [ForeignKey("CategoryId")]
    //    public Categories Category { get; set; }
    //    public int CategoryId { get; set; }
    //}
}
