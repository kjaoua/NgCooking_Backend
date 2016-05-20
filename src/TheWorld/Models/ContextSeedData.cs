using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NgCooking.Models.Repositories;

namespace NgCooking.Models
{
    public class ContextSeedData
    {
        private NgCookingContext _context;
        public ContextSeedData(NgCookingContext context)
        {
            _context = context;

        }

        public void EnsureSeedData()
        {
            EFRepository<Communaute> CommunauteManager = new EFRepository<Communaute>(_context);
            EFRepository<Recettes> RecettesManager = new EFRepository<Recettes>(_context);
            EFRepository<Ingredients> IngredientsManager = new EFRepository<Ingredients>(_context);
            EFRepository<Categories> CategoriesManager = new EFRepository<Categories>(_context);
            EFRepository<Comments> CommentsManager = new EFRepository<Comments>(_context);

            #region add communaute

            if (!_context.Communaute.Any())
            {
                //add new data
                //var communaute = new Communaute()
                //{
                //    //id = 1,
                //    firstname = "khaled",
                //    surname = "jaoua",
                //    email = "jaoua.khaled@gmail.com",
                //    bio = "nothing",
                //    birth = 1990,
                //    city = "Paris",
                //    level = 3,
                //    password = "0754209030",
                //    picture = "url"
                //};
                //CommunauteManager.Add(communaute);
               // CommunauteManager.Save();
            }
            #endregion
            #region add Ingredients

            if (!_context.Ingredients.Any())
            {
                //add new data
                //var ingredients = new Ingredients()
                //{
                //    calories = 250,
                //    category = new Categories()
                //    {
                //        name = "categ1",
                //        nameToDisplay = "cat1"
                //    },
                //    picture = "url",
                //    name = "ing1",
                //    isAvailable = true

                //};
                //IngredientsManager.Add(ingredients);
                //CategoriesManager.Add(ingredients.category);
                //CategoriesManager.Save();
                //IngredientsManager.Save();
            }
            #endregion
            #region add Recettes
            if (!_context.Recettes.Any())
            {
                //add new data
                //var recettes = new Recettes()
                //{

                //    nameToDisplay = "recette",
                //    name = "recette",
                //    creator = _context.Communaute.FirstOrDefault(),
                //    comments = new List<Comments>()
                //    {
                //        new Comments(){comment ="efhv eucbeoc rzlcn", mark = 4,title = "hello",user = _context.Communaute.FirstOrDefault() },
                //        new Comments(){comment ="fevnelv erfe", mark = 3,title = "hi",user = _context.Communaute.FirstOrDefault() }
                //    },
                //    ingredients = _context.Ingredients.ToList(),
                //    picture = "url",
                //    isAvailable = true,
                //    preparation = "jechece ekcbeoc kcjbecb elch"

                //};
                //RecettesManager.Add(recettes);
                //CommentsManager.AddRange(recettes.comments);

                //CommentsManager.Save();
                //RecettesManager.Save();
            }
            #endregion
            

        }
    }
}
