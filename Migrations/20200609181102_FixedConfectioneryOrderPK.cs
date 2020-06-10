using Microsoft.EntityFrameworkCore.Migrations;

namespace tut13.Migrations
{
    public partial class FixedConfectioneryOrderPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectionery_Order",
                table: "Confectionery_Order");

            migrationBuilder.DropIndex(
                name: "IX_Confectionery_Order_IdConfectionery",
                table: "Confectionery_Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectionery_Order",
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order",
                column: "IdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectionery_Order",
                table: "Confectionery_Order");

            migrationBuilder.DropIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectionery_Order",
                table: "Confectionery_Order",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdConfectionery",
                table: "Confectionery_Order",
                column: "IdConfectionery");
        }
    }
}
