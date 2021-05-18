using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifications_DAL.Migrations
{
    public partial class AlterExpirationTimeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expirationTime",
                table: "subscriptions",
                newName: "expiration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expiration",
                table: "subscriptions",
                newName: "expirationTime");
        }
    }
}
