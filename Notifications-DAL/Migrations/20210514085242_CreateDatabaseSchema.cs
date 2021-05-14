using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifications_DAL.Migrations
{
    public partial class CreateDatabaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "keys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p256hd = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    auth = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    endpoint = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    expirationTime = table.Column<double>(type: "float", nullable: false),
                    keys_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscriptions_keys",
                        column: x => x.keys_id,
                        principalTable: "keys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_keys_id",
                table: "subscriptions",
                column: "keys_id");

            migrationBuilder.CreateIndex(
                name: "UQ__subscrip__00C5A355188809D9",
                table: "subscriptions",
                column: "endpoint",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "keys");
        }
    }
}
