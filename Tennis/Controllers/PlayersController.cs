using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennis.Models;

namespace Tennis.Controllers
{
	[Route("api/players")]
	public class PlayersController : Controller
	{
		private long start = 1504224000000;
		private int year = 2017;
		private int month = 10;
		private int timeKoeff = 3600000;
		private TennisDbContext db;
		public PlayersController(TennisDbContext tennisContext)
		{
			db = tennisContext;
		}
		public IActionResult Index()
		{
			return Ok(new
			{
				model = db.Players,
				apiStatus = "successfully_retrieved_reservs",
				message = "Successfully able to retrieve reservs",
				success = true
			});
		}
		[HttpGet("GetByMonth/{month}")]
		public IActionResult GetByMonth(int month = 0)
		{
			if (month == 0) month = DateTime.Now.Month;
			var reservs = db.Reservations.Where(s => s.Month == month && s.Year == year);
			var result = db.Players.Select(s => new
			{
				s.Id,
				s.Name,
				s.Email,
				s.Phone,
				Hours = reservs.Where(r => db.SubscribePlayers.Where(p => p.PlayerId == s.Id).Any(p => p.ReservationId == r.Id)).Sum(p => p.Range / timeKoeff),
				Orders = reservs.Where(r => db.SubscribePlayers.Where(p => p.PlayerId == s.Id && p.Order).Any(p => p.ReservationId == r.Id)).Sum(p => p.Total),
				Pays = db.Payments.Where(p => p.Month == month && p.Year == year && p.PlayerId == s.Id).Sum(p => p.Total)
			}).OrderBy(s => s.Name);
			return Ok(new
			{
				model = result,
				apiStatus = "successfully_retrieved_customers",
				message = "Successfully able to retrieve customers",
				success = true
			});
		}
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(int id = 0)
		{
			var player = db.Players.FirstOrDefault(s => s.Id == id);
			return Ok(new
			{
				model = player,
				apiStatus = "successfully_retrieved_customers",
				message = "Successfully able to retrieve customers",
				success = true
			});
		}
	}
}