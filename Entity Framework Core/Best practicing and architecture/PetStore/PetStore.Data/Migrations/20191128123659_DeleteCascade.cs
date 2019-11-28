using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class DeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Brands_BrandId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Categories_CategoryId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Orders_OrderId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrders_Orders_OrderId",
                table: "ToyOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrders_Toys_ToyId",
                table: "ToyOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Brands_BrandId",
                table: "Toys");

            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Categories_CategoryId",
                table: "Toys");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Brands_BrandId",
                table: "Foods",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Categories_CategoryId",
                table: "Pets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Orders_OrderId",
                table: "Pets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrders_Orders_OrderId",
                table: "ToyOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrders_Toys_ToyId",
                table: "ToyOrders",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Brands_BrandId",
                table: "Toys",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Categories_CategoryId",
                table: "Toys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Brands_BrandId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Categories_CategoryId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Orders_OrderId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrders_Orders_OrderId",
                table: "ToyOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrders_Toys_ToyId",
                table: "ToyOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Brands_BrandId",
                table: "Toys");

            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Categories_CategoryId",
                table: "Toys");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Brands_BrandId",
                table: "Foods",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Categories_CategoryId",
                table: "Pets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Orders_OrderId",
                table: "Pets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrders_Orders_OrderId",
                table: "ToyOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrders_Toys_ToyId",
                table: "ToyOrders",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Brands_BrandId",
                table: "Toys",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Categories_CategoryId",
                table: "Toys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
