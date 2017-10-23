using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennis.Models;

namespace Tennis.Controllers
{
	[Route("api/treners")]
	public class TrenersController : Controller
	{
		private TennisDbContext db;
		private long start = 1504224000000;
		private int year = 2017;
		private int month = 10;
		private int timeKoeff = 3600000;
		public TrenersController(TennisDbContext tennisContext)
		{
			db = tennisContext;
		}
		public IActionResult Index()
		{
			return Ok(new
			{
				model = db.Treners,
				apiStatus = "successfully_retrieved_treners",
				message = "Successfully able to retrieve treners",
				success = true
			});
		}
	}
}