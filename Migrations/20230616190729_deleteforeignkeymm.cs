using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_ReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteforeignkeymm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_Trip_Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Trip_Id",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
