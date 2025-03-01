using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hoicham.Migrations
{
    /// <inheritdoc />
    public partial class Db6th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Users_ApprovedById",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_StockCounts_Users_ApprovedByUserId",
                table: "StockCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockCounts_Users_CountedByUserId",
                table: "StockCounts");

            migrationBuilder.DropIndex(
                name: "IX_StockCounts_ApprovedByUserId",
                table: "StockCounts");

            migrationBuilder.DropIndex(
                name: "IX_StockCounts_CountedByUserId",
                table: "StockCounts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ApprovedById",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "StockCounts");

            migrationBuilder.DropColumn(
                name: "CountedByUserId",
                table: "StockCounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovedById",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedByUserId",
                table: "StockCounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountedByUserId",
                table: "StockCounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovedById",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCounts_ApprovedByUserId",
                table: "StockCounts",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCounts_CountedByUserId",
                table: "StockCounts",
                column: "CountedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ApprovedById",
                table: "PurchaseOrders",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Users_ApprovedById",
                table: "PurchaseOrders",
                column: "ApprovedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockCounts_Users_ApprovedByUserId",
                table: "StockCounts",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockCounts_Users_CountedByUserId",
                table: "StockCounts",
                column: "CountedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
