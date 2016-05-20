using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using NgCooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NgCooking.Models.Repositories;
using System.Net;
using AutoMapper;
using Newtonsoft;

namespace NgCooking.APIControllers
{
    public class RecettesController: Controller
    {
 private NgCookingContext _context = new NgCookingContext();
        private EFRepository<Recettes> RecettesManager;
        private EFRepository<Comments> CommentsManager;
        private EFRepository<RecettesIngredients> RecettesIngredientsManager;

        [HttpGet("/api/Recettes")]
        public JsonResult Get()
        {
             RecettesManager = new EFRepository<Recettes>(_context);
            RecettesIngredientsManager = new EFRepository<RecettesIngredients>(_context);
            var Recettes = RecettesManager.GetAll().Include(a=>a.Comments).Include(b=>b.RecettesIngredients).Include(a=>a.Creator).ToList();
            HashSet<RecetteToFront> RecetteToFrontList = new HashSet<RecetteToFront>();
            foreach (var Rct in Recettes)
            {
                RecetteToFront RecetteToFront = new RecetteToFront();
                RecetteToFront.name = Rct.name;
                RecetteToFront.id = Rct.nameToDisplay;
                RecetteToFront.CreatorId = Rct.CreatorId;
                RecetteToFront.Creator = Rct.Creator;
                RecetteToFront.isAvailable = Rct.isAvailable;
                RecetteToFront.picture = Rct.picture;
                RecetteToFront.Comments = Rct.Comments;
                RecetteToFront.preparation = Rct.preparation;
                foreach (var ing in Rct.RecettesIngredients)
                {
                    Ingredients ingredient = RecettesIngredientsManager.GetAll().Include(a => a.Ingredient).FirstOrDefault(b => b.IngredientId == ing.IngredientId && b.RecetteId == ing.RecetteId).Ingredient;
                    RecetteToFront.Ingredients.Add(ingredient.id); 
                }
                RecetteToFrontList.Add(RecetteToFront);
            }
            // string res = Newtonsoft.Json.JsonConvert.SerializeObject(Recettes);
            return Json(RecetteToFrontList);
        }   
        [HttpPost("/api/Recettes")]
        public JsonResult Post([FromBody]List<Recettes> newRecettes)
        {
            RecettesManager = new EFRepository<Recettes>(_context);
            CommentsManager = new EFRepository<Comments>(_context);
            try
            {
                foreach(var recette in newRecettes)
                {
                    RecettesManager.Add(recette);
                    CommentsManager.AddRange(recette.Comments);
                    //var rect = Mapper.Map<Recettes>(communaute);
                    
                    CommentsManager.Save();

                }
                RecettesManager.Save();
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }
            catch(Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return Json(new { message = e.Message });
            }
            
        }
    }
}
