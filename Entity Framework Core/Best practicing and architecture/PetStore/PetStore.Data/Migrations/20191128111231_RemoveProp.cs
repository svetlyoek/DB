using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class RemoveProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Foods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Foods",
                nullable: false,
                defaultValue: 0);
        }
    }
}
