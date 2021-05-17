using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifications_DAL.Migrations
{
    public partial class UpdateColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "p256hd",
                table: "keys",
                newName: "p256dh");

            migrationBuilder.AlterColumn<float>(
                name: "expirationTime",
                table: "subscriptions",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "p256dh",
                table: "keys",
                newName: "p256hd");

            migrationBuilder.AlterColumn<double>(
                name: "expirationTime",
                table: "subscriptions",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
