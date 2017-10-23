using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennis.Models;

namespace Tennis.Controllers
{
	[Route("api/prices")]
	public class PricesController : Controller
	{
		private TennisDbContext db;
		public PricesController(TennisDbContext tennisContext)
		{
			db = tennisContext;
		}
		public IActionResult Index()
		{
			return Ok(new
			{
				model = db.Prices,
				apiStatus = "successfully_retrieved_reservs",
				message = "Successfully able to retrieve reservs",
				success = true
			});
		}
	}
}