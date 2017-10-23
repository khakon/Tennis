using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tennis.Models;

namespace Tennis.Migrations
{
    [DbContext(typeof(TennisDbContext))]
    [Migration("20170928235056_RenameSubscribe")]
    partial class RenameSubscribe
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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

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

            modelBuilder.Entity("Tennis.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Tennis.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<int>("Range");

                    b.Property<int>("Start");

                    b.Property<int?>("TimetableId");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.HasIndex("TimetableId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Tennis.Models.SubscribePlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("ReservationId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ReservationId");

                    b.ToTable("SubscribePlayers");
                });

            modelBuilder.Entity("Tennis.Models.SubscribeTrener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerId");

                    b.Property<int>("ReservationId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ReservationId");

                    b.ToTable("SubscribeTreners");
                });

            modelBuilder.Entity("Tennis.Models.Timetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

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

            modelBuilder.Entity("Tennis.Models.Reservation", b =>
                {
                    b.HasOne("Tennis.Models.Court", "Court")
                        .WithMany("Reservations")
                        .HasForeignKey("CourtId")
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
                    b.HasOne("Tennis.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tennis.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
