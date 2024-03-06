using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolidAPI.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigments_TicketId",
                table: "TicketAssigments",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAssigments_Tickets_TicketId",
                table: "TicketAssigments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketAssigments_Tickets_TicketId",
                table: "TicketAssigments");

            migrationBuilder.DropIndex(
                name: "IX_TicketAssigments_TicketId",
                table: "TicketAssigments");
        }
    }
}
