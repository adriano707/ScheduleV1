using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixReferencesInScheduleEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEvent_Event_ScheduleId",
                table: "ScheduleEvent");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEvent_EventId",
                table: "ScheduleEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEvent_Event_EventId",
                table: "ScheduleEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEvent_Event_EventId",
                table: "ScheduleEvent");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEvent_EventId",
                table: "ScheduleEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEvent_Event_ScheduleId",
                table: "ScheduleEvent",
                column: "ScheduleId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
