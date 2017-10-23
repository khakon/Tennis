using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennis.Models;

namespace Tennis.Controllers
{
    public class CourtsController : Controller
    {
        private TennisDbContext db;
        public CourtsController(TennisDbContext tennisContext)
        {
            db = tennisContext;
        }
        [Route("seed/[controller]")]
        public IActionResult Seed()
        {
            for (int i = 2; i < 7; i++)
            {
                db.Add(new Court { Name = "Court#" + i.ToString(), Adress = "Adress#" + i.ToString(), Description = "Description#" + i.ToString(), Image = "images/" + i.ToString() + ".jpg", Rating = i, RegionId = i%2 == 0? 1 : 2});
                db.SaveChanges();
            }
            return Ok(new { apiStatus = "successfully_retrieved_products", message = "Successfully seeding Courts", success = true });
        }

        [HttpGet]
        [Route("api/courts")]
        public IActionResult GetAll() //
        {
			var listId = new List<int> { 14, 12, 15, 18, 17 };
			return Ok(new { model = db.Courts.Where(s=> listId.Contains(s.Id)), apiStatus = "successfully_retrieved_products", message = "Successfully able to retrieve products", success = true });
        }
        [HttpGet]
        [Route("api/court")]
        public IActionResult Get(int key)
        {
            return Ok(new { model = db.Courts.FirstOrDefault(s=>s.Id == key), apiStatus = "successfully", message = "Successfully able to retrieve courts", success = true });
        }
        [HttpPost]
        [Produces("application/json")]
        [Route("api/courts")]
        public IActionResult Add(Court model)
        {
            try
            {
                if (db.Courts.Any(s => s.Id == model.Id))
                {
                    var item = db.Courts.FirstOrDefault(s => s.Id == model.Id);
                    item.Name = model.Name;
                    item.Adress = model.Adress;
                    item.Description = model.Description;
                    item.Image = model.Image;
                    item.Rating = model.Rating;
                    item.RegionId = model.RegionId;
                    db.Update(item);
                    db.SaveChanges();
                    return Ok(new { model = db.Courts, apiStatus = "successfully_updated", message = "Successfully updated the court", success = true });
                }
                db.Add(model);
                db.SaveChanges();
                return Ok(new { model = db.Courts, apiStatus = "successfully_added", message = "Successfully added the court", success = true });
            }
            catch (Exception ex)
            {
                return Ok(new { apiStatus = "internal_error_added", message = ex.Message, success = false });
            }
        }

        [HttpDelete("api/courts/{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (!db.Courts.Any(s => s.Id == Id)) return Ok(new { apiStatus = "error_deleted", message = Id.ToString() + " Error, region don't found", success = false });
                var item = db.Courts.FirstOrDefault(s => s.Id == Id);
                db.Remove(item);
                db.SaveChanges();
                return Ok(new { model = db.Courts, apiStatus = "successfully_deleted", message = "Successfully deleted the region", success = true });
            }
            catch (Exception ex)
            {
                return Ok(new { apiStatus = "internal_error_deleted", message = ex.Message, success = false });
            }
        }
    }
}