using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS4790A3.Migrations
{
    public partial class addeduseridtocomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
