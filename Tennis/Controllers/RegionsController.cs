using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennis.Models;

namespace Tennis.Controllers
{
    public class RegionsController : Controller
    {
        private TennisDbContext db;
        public RegionsController(TennisDbContext tennisContext)
        {
            db = tennisContext;
        }
        [HttpGet]
        [Route("api/regions")]
        public IActionResult GetAll() //
        {
            return Ok(new { model = db.Regions, apiStatus = "successfully_retrieved_products", message = "Successfully able to retrieve products", success = true });
        }
        [HttpPost]
        [Produces("application/json")]
        [Route("api/regions")]
        public IActionResult Add(Region model)
        {
            try
            {
                if (db.Regions.Any(s => s.Id == model.Id))
                {
                    var item = db.Regions.FirstOrDefault(s => s.Id == model.Id);
                    item.Name = model.Name;
                    db.Update(item);
                    db.SaveChanges();
                    return Ok(new { model = db.Regions, apiStatus = "successfully_updated", message = "Successfully updated the product", success = true });
                }
                db.Add(model);
                db.SaveChanges();
                return Ok(new { model = db.Regions, apiStatus = "successfully_added", message = "Successfully added the product", success = true });
            }
            catch (Exception ex)
            {
                return Ok(new { apiStatus = "internal_error_added", message = ex.Message, success = false });
            }
        }

        [HttpDelete("api/Regions/{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (!db.Regions.Any(s => s.Id == Id)) return Ok(new { apiStatus = "error_deleted", message = Id.ToString() + " Error, region don't found", success = false });
                var item = db.Regions.FirstOrDefault(s => s.Id == Id);
                db.Remove(item);
                db.SaveChanges();
                return Ok(new { model = db.Regions, apiStatus = "successfully_deleted", message = "Successfully deleted the region", success = true });
            }
            catch (Exception ex)
            {
                return Ok(new { apiStatus = "internal_error_deleted", message = ex.Message, success = false });
            }
        }
    }
}