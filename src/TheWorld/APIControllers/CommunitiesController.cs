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
    public class CommunitiesController : Controller
    {
        private NgCookingContext _context = new NgCookingContext();
        private EFRepository<Communaute> CommunauteManager;

        [HttpGet("/api/Communities")]
        #region get Communaute Method
        public JsonResult Get()
        {
            CommunauteManager = new EFRepository<Communaute>(_context);
            var Communaute = CommunauteManager.GetAll().ToList();


            return Json(Communaute);
        }
        #endregion
        [HttpPost("/api/Communities")]
        #region post Communaute Method

        public JsonResult Post([FromBody]List<Communaute> newCommunaute)
        {
            CommunauteManager = new EFRepository<Communaute>(_context);
            try
            {

                // var commun = Mapper.Map<Communaute>(newCommunaute);
                foreach (var Comm in newCommunaute)
                {
                    if (CommunauteManager.GetAll().Any(a => a.email == Comm.email))
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;

                        return Json(false);
                    }

                }
                CommunauteManager.AddRange(newCommunaute);


                CommunauteManager.Save();
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return Json(new { message = e.InnerException });
            }

        }
        #endregion
    }
}
