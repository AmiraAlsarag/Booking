using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_ReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeytotripinreservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Trip_Id",
                table: "Reservations",
                column: "Trip_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_Trip_Id",
                table: "Reservations",
                column: "Trip_Id",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_Trip_Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Trip_Id",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CreationDate", "CustomerName", "Notes", "ReservationDate", "ReservedBy", "Trip_Id" },
                values: new object[] { 1, new DateTime(2023, 6, 14, 19, 42, 45, 318, DateTimeKind.Local).AddTicks(9217), "fayrouz", "baby", new DateTime(2023, 6, 14, 19, 42, 45, 318, DateTimeKind.Local).AddTicks(9300), "mamadmin", 1 });
        }
    }
}
