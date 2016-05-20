using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
namespace NgCooking.Models
{
    public class NgCookingContext: DbContext
    {

        public NgCookingContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Communaute> Communaute { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Recettes> Recettes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:NgCookingContextConnection"];
           
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RecettesIngredients>()
               .HasKey(t => new { t.IngredientId, t.RecetteId });

            modelBuilder.Entity<RecettesIngredients>()
                .HasOne(pt => pt.Recette)
                .WithMany(p => p.RecettesIngredients)
                .HasForeignKey(pt => pt.RecetteId);

            modelBuilder.Entity<RecettesIngredients>()
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.RecettesIngredients)
                .HasForeignKey(pt => pt.IngredientId);
            modelBuilder.Entity<Ingredients>().HasKey(q => q.IngredientId);
            //modelBuilder.Entity<Ingredients>()
            //   .HasOne(p => p.Category)
            //   .WithMany(b => b.Ingredients);
            //modelBuilder.Entity<Comments>()
            //   .HasOne(p => p.Recettes)
            //   .WithMany(b => b.Comments);
            //modelBuilder.Entity<Recettes>()
            //   .HasOne(p => p.Creator)
            //   .WithMany(b => b.Recettes);
        }


    }
}
