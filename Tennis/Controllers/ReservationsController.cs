using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennis.Models;

namespace Tennis.Controllers
{
	[Route("api/reservs")]
	public class ReservationsController : Controller
	{
		private long start = 1504224000000;
		private int year = 2017;
		private int month = 10;
		private TennisDbContext db;
		public ReservationsController(TennisDbContext tennisContext)
		{
			db = tennisContext;
		}
		[HttpGet("{id}")]
		public IActionResult Index(int id = 14)
		{
			return Ok(new
			{
				model = db.Reservations.Where(s => s.Start >= start && s.CourtId == id).Select(s => new // || s.CourtId == 14 || s.CourtId == 12))
				{
					s.Id,
					s.Start,
					s.Range,
					s.CourtId,
					CourtName = s.Court.Name,
					s.PriceId,
					Lesson = s.Price.Name,
					TrenerId = db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id) == null ? 0 : db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id).TrenerId,
					PlayerCount = db.SubscribePlayers.Where(t => t.ReservationId == s.Id).Count(),
					s.Total
				}),
				apiStatus = "successfully_retrieved_reservs",
				message = "Successfully able to retrieve reservs",
				success = true
			});
		}
		[HttpGet("GetCustomers/{id}")]
		public IActionResult GetCustomers(int id = 14)
		{
			var res = db.Reservations.Where(s => s.Start >= start && s.CourtId == id);
			return Ok(new
			{
				model = db.SubscribePlayers.Where(s => res.Any(r => r.Id == s.ReservationId)).Select(s => new { s.ReservationId, s.PlayerId, name = s.Player.Name }),
				apiStatus = "successfully_retrieved_customers",
				message = "Successfully able to retrieve customers",
				success = true
			});
		}
		[HttpGet("GetByMonth/{month}")]
		public IActionResult GetByMonth(int month = 0)
		{
			if (month == 0) month = DateTime.Now.Month;
			var reservs = db.Reservations.Where(s => s.Month == month && s.Year == year);
			var result = reservs.Select(s => new
			{
				s.Id,
				s.Start,
				s.Range,
				Price = s.Price.Name,
				Court = s.Court.Name,
				s.PriceId,
				s.CourtId,
				s.Total,
				TrenerId = db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id) == null ? 0 : db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id).TrenerId,
				Trener = db.Treners.FirstOrDefault(r => r.Id == db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id).TrenerId).Name,
				PlayersCount = db.SubscribePlayers.Where(t => t.ReservationId == s.Id).Count()
			}).OrderByDescending(s => s.Start).ThenBy(s => s.CourtId);
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
			var reservs = db.Reservations.Where(s => s.Id == id);
			var result = reservs.Select(s => new
			{
				s.Id,
				s.Start,
				s.Range,
				Price = s.Price.Name,
				Court = s.Court.Name,
				s.PriceId,
				s.CourtId,
				s.Total,
				TrenerId = db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id) == null ? 0 : db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id).TrenerId,
				Trener = db.Treners.FirstOrDefault(r => r.Id == db.SubscribeTreners.FirstOrDefault(t => t.ReservationId == s.Id).TrenerId).Name,
				PlayersCount = db.SubscribePlayers.Where(t => t.ReservationId == s.Id).Count()
			}).FirstOrDefault();
			return Ok(new
			{
				model = result,
				apiStatus = "successfully_retrieved_customers",
				message = "Successfully able to retrieve customers",
				success = true
			});
		}
	}
}