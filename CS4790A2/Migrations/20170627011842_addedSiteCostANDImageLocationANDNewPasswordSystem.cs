using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS4790A3.Migrations
{
    public partial class addedSiteCostANDImageLocationANDNewPasswordSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imglocation",
                table: "Site",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "siteAvailable",
                table: "Site",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "siteCost",
                table: "Site",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imglocation",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "siteAvailable",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "siteCost",
                table: "Site");
        }
    }
}
