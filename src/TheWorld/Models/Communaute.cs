using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NgCooking.Models
{
    public class Communaute
    {
        public int id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string picture { get; set; }
        [Required]
        public int level { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int birth { get; set; }
        [Required]
        public string bio { get; set; }
        //public virtual ICollection<Recettes> Recettes { get; set; }
        //public Communaute()
        //{
        //    Recettes = new HashSet<Recettes>();
        //}
    }
}
