using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileRecharge.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    RechargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    CustomerPhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<int>(type: "int", nullable: false),
                    Voice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMS = table.Column<int>(type: "int", nullable: false),
                    Validity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.RechargeId);
                    table.ForeignKey(
                        name: "FK_History_Customers_CustomerPhoneNumber",
                        column: x => x.CustomerPhoneNumber,
                        principalTable: "Customers",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_CustomerPhoneNumber",
                table: "History",
                column: "CustomerPhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
