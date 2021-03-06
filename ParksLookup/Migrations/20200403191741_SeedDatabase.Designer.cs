﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksLookup.Models;

namespace ParksLookup.Migrations
{
    [DbContext(typeof(ParksLookupContext))]
    [Migration("20200403191741_SeedDatabase")]
    partial class SeedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParksLookup.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ParksLookup.Models.Detail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("ParkId");

                    b.Property<int>("Rating");

                    b.Property<int?>("UserId");

                    b.HasKey("DetailId");

                    b.HasIndex("ParkId");

                    b.HasIndex("UserId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            DetailId = 1,
                            Address = "5500 W Hwy 488, Baker, NV 89311",
                            Description = "Ancient bristlecone pines",
                            ParkId = 1,
                            Rating = 5
                        },
                        new
                        {
                            DetailId = 2,
                            Address = "16001 Corn Creek Rd, Las Vegas, NV 89166",
                            Description = "Established as the 405th unit of the National Park Service.",
                            ParkId = 2,
                            Rating = 2
                        },
                        new
                        {
                            DetailId = 3,
                            Address = "2005 NV-28, Incline Village, NV 89452",
                            Description = "The largest alpine lake in North America.",
                            ParkId = 3,
                            Rating = 5
                        },
                        new
                        {
                            DetailId = 4,
                            Address = "30 Lake Pkwy, South Lake Tahoe, CA 96150",
                            Description = "One the most accessible parks in the Tahoe Basin.",
                            ParkId = 4,
                            Rating = 3
                        });
                });

            modelBuilder.Entity("ParksLookup.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Management")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Location = "Baker, NV",
                            Management = "National",
                            Name = "Great Basin National Park"
                        },
                        new
                        {
                            ParkId = 2,
                            Location = "Las Vegas, NV",
                            Management = "National",
                            Name = "Tule Springs Fossil Beds National Monument"
                        },
                        new
                        {
                            ParkId = 3,
                            Location = "Incline Village, NV",
                            Management = "State",
                            Name = "Sand Harbor"
                        },
                        new
                        {
                            ParkId = 4,
                            Location = "South Lake Tahoe, CA",
                            Management = "State",
                            Name = "Van Sickle"
                        });
                });

            modelBuilder.Entity("ParksLookup.Models.Detail", b =>
                {
                    b.HasOne("ParksLookup.Models.Park")
                        .WithMany("Details")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ParksLookup.Entities.User", "User")
                        .WithMany("Details")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
