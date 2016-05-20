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
    public class CategoriesController : Controller
    {
        private NgCookingContext _context = new NgCookingContext();
        private EFRepository<Categories> CategoriesManager;
        
        [HttpGet("/api/Categories")]
        #region get Categories Method
        public JsonResult Get()
        {
            CategoriesManager = new EFRepository<Categories>(_context);
            var Categories = CategoriesManager.GetAll().ToList();


            return Json(Categories);
        }
        #endregion
        [HttpPost("/api/Categories")]
        #region post Categories method
        public JsonResult Post([FromBody]List<Categories> newCategories)
        {
            CategoriesManager = new EFRepository<Categories>(_context);
            try
            {


                CategoriesManager.AddRange(newCategories);


                CategoriesManager.Save();
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
