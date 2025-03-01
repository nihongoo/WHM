using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hoicham.Migrations
{
    /// <inheritdoc />
    public partial class Db7th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceHistories_Users_UpdatedById",
                table: "ProductPriceHistories");

            migrationBuilder.DropIndex(
                name: "IX_ProductPriceHistories_UpdatedById",
                table: "ProductPriceHistories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_UpdatedById",
                table: "ProductPriceHistories",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceHistories_Users_UpdatedById",
                table: "ProductPriceHistories",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
