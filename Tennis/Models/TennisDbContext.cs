using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tennis.Models
{
    public class TennisDbContext:DbContext
    {
        public DbSet<Court> Courts { get; set; }
        public DbSet<SubscribePlayer> SubscribePlayers { get; set; }
        public DbSet<SubscribeTrener> SubscribeTreners { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Trener> Treners { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Timetable> TimeTables { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public TennisDbContext(DbContextOptions<TennisDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
