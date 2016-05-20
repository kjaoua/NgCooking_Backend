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

namespace NgCooking.APIControllers
{
    public class IngredientsController : Controller
    {
        private NgCookingContext _context = new NgCookingContext();
        private EFRepository<Ingredients> IngredientsManager;

        [HttpGet("/api/Ingredients")]
        #region get Ingredients Method

        public JsonResult Get()
        {
            IngredientsManager = new EFRepository<Ingredients>(_context);
            var Ingredients = IngredientsManager.GetAll().Include(a=>a.Category).ToList();
           // Ingredients Ing = new Ingredients();

            return Json(Ingredients);
        }
        #endregion
        [HttpPost("/api/Ingredients")]
        #region get Ingredients Method

        public JsonResult Post([FromBody]List<Ingredients> newIngredients)
        {
            IngredientsManager = new EFRepository<Ingredients>(_context);
            try
            {


                IngredientsManager.AddRange(newIngredients);


                IngredientsManager.Save();
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return Json(new { message = e.Message });
            }

        }
        #endregion
    }
}
