﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CS4790A3.Data;

namespace CS4790A3.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20170628191722_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS4790A3.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SiteID");

                    b.Property<int>("UserID");

                    b.Property<string>("cmtComment")
                        .IsRequired();

                    b.Property<DateTime>("cmtDate");

                    b.HasKey("CommentID");

                    b.HasIndex("SiteID");

                    b.HasIndex("UserID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("CS4790A3.Models.Site", b =>
                {
                    b.Property<int>("SiteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("imglocation");

                    b.Property<bool>("siteAvailable");

                    b.Property<double>("siteCost");

                    b.Property<string>("siteDescription")
                        .IsRequired();

                    b.Property<int>("siteGas");

                    b.Property<string>("siteLandType")
                        .IsRequired();

                    b.Property<double>("siteLat");

                    b.Property<bool>("siteLevel");

                    b.Property<double>("siteLong");

                    b.Property<string>("siteName")
                        .IsRequired();

                    b.Property<bool>("siteOffroad");

                    b.Property<string>("siteUses");

                    b.Property<bool>("siteWater");

                    b.HasKey("SiteID");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("CS4790A3.Models.SitesPurchased", b =>
                {
                    b.Property<int>("SitesPurchasedID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SiteID");

                    b.Property<int>("UserID");

                    b.HasKey("SitesPurchasedID");

                    b.HasIndex("SiteID");

                    b.HasIndex("UserID");

                    b.ToTable("SitesPurchased");
                });

            modelBuilder.Entity("CS4790A3.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("accountType");

                    b.Property<string>("userEmail")
                        .IsRequired();

                    b.Property<string>("userName")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CS4790A3.Models.Comment", b =>
                {
                    b.HasOne("CS4790A3.Models.Site")
                        .WithMany("Comments")
                        .HasForeignKey("SiteID");

                    b.HasOne("CS4790A3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS4790A3.Models.SitesPurchased", b =>
                {
                    b.HasOne("CS4790A3.Models.Site", "site")
                        .WithMany()
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS4790A3.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
