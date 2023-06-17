using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_ReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedtablereservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_TripId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Reservations",
                newName: "Trip_Id");

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CreationDate", "CustomerName", "Notes", "ReservationDate", "ReservedBy", "Trip_Id" },
                values: new object[] { 1, new DateTime(2023, 6, 14, 19, 42, 45, 318, DateTimeKind.Local).AddTicks(9217), "fayrouz", "baby", new DateTime(2023, 6, 14, 19, 42, 45, 318, DateTimeKind.Local).AddTicks(9300), "mamadmin", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Trip_Id",
                table: "Reservations",
                newName: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_TripId",
                table: "Reservations",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
