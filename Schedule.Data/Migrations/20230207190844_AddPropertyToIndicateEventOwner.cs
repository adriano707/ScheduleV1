using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyToIndicateEventOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_UserId",
                table: "Schedule");

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "ScheduleEvent",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_UserId",
                table: "Schedule",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_UserId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "ScheduleEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_UserId",
                table: "Schedule",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
