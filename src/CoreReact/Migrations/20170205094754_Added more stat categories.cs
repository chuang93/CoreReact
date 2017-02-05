using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreReact.Migrations
{
    public partial class Addedmorestatcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ApgInLoss",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ApgInWin",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FgPerInLoss",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FgPerInWin",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RpgInLoss",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RpgInWin",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreePerInLoss",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThreePerInWin",
                table: "PlayerProfile",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApgInLoss",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "ApgInWin",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "FgPerInLoss",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "FgPerInWin",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "RpgInLoss",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "RpgInWin",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "ThreePerInLoss",
                table: "PlayerProfile");

            migrationBuilder.DropColumn(
                name: "ThreePerInWin",
                table: "PlayerProfile");
        }
    }
}
