using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightProject.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedArrivalDateOnFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Flights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Flights");
        }
    }
}
