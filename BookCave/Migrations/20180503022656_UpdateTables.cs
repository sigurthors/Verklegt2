using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Authors",
                newName: "Name");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Books",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
