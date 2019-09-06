using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HotelCalifornia.Data.Migrations
{
    public partial class HotelSupported2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckIntoDate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "Guests");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIntoRoomDate",
                table: "Guests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutRoomDate",
                table: "Guests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckIntoRoomDate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CheckOutRoomDate",
                table: "Guests");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIntoDate",
                table: "Guests",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "Guests",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
