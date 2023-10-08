using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Service.Migrations
{
    /// <inheritdoc />
    public partial class Update_Transaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ItemTypeId",
                table: "Transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Persons",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ItemTypeId",
                table: "Transactions",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_ItemTypeId",
                table: "Transactions",
                column: "ItemTypeId",
                principalTable: "GeneralTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_ItemTypeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ItemTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Persons");
        }
    }
}
