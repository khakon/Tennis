using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tennis.Models;

namespace Tennis.Migrations
{
    [DbContext(typeof(TennisDbContext))]
    [Migration("20171011120052_OrderSkippingSub")]
    partial class OrderSkippingSub
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tennis.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<double>("Rating");

                    b.Property<int>("RegionId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("Tennis.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<int>("PlayerId");

                    b.Property<decimal>("Total");

                    b.Property<int>("TrenerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TrenerId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Tennis.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Tennis.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountPlayer");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("PriceDay");

                    b.Property<decimal>("PriceNight");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Tennis.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Tennis.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourtId");

                    b.Property<bool>("Deleted");

                    b.Property<int>("PriceId");

                    b.Property<long>("Range");

                    b.Property<long>("Start");

                    b.Property<int?>("TimetableId");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.HasIndex("PriceId");

                    b.HasIndex("TimetableId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Tennis.Models.SubscribePlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Order");

                    b.Property<int>("PlayerId");

                    b.Property<int>("ReservationId");

                    b.Property<bool>("Skipping");

                    b.Property<long>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ReservationId");

                    b.ToTable("SubscribePlayers");
                });

            modelBuilder.Entity("Tennis.Models.SubscribeTrener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<int>("ReservationId");

                    b.Property<long>("TimeStamp");

                    b.Property<int>("TrenerId");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("TrenerId");

                    b.ToTable("SubscribeTreners");
                });

            modelBuilder.Entity("Tennis.Models.Timetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("Tennis.Models.Trener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Treners");
                });

            modelBuilder.Entity("Tennis.Models.Court", b =>
                {
                    b.HasOne("Tennis.Models.Region", "Region")
                        .WithMany("Courts")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tennis.Models.Payment", b =>
                {
                    b.HasOne("Tennis.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tennis.Models.Trener", "Trener")
                        .WithMany()
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tennis.Models.Reservation", b =>
                {
                    b.HasOne("Tennis.Models.Court", "Court")
                        .WithMany("Reservations")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tennis.Models.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tennis.Models.Timetable")
                        .WithMany("Reservations")
                        .HasForeignKey("TimetableId");
                });

            modelBuilder.Entity("Tennis.Models.SubscribePlayer", b =>
                {
                    b.HasOne("Tennis.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tennis.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tennis.Models.SubscribeTrener", b =>
                {
                    b.HasOne("Tennis.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tennis.Models.Trener", "Trener")
                        .WithMany()
                        .HasForeignKey("TrenerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
