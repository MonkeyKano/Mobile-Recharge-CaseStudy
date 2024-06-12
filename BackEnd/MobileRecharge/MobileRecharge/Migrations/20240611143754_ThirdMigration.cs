using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileRecharge.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Customers_CustomerPhoneNumber",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_CustomerPhoneNumber",
                table: "History");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "History");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerPhoneNumber",
                table: "History",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_History_CustomerPhoneNumber",
                table: "History",
                column: "CustomerPhoneNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Customers_CustomerPhoneNumber",
                table: "History",
                column: "CustomerPhoneNumber",
                principalTable: "Customers",
                principalColumn: "PhoneNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
