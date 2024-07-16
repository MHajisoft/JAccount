using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Service.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Transaction_Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_AccountTypeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_CostTypeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_ItemTypeId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Transactions",
                newName: "ReasonId");

            migrationBuilder.RenameColumn(
                name: "CostTypeId",
                table: "Transactions",
                newName: "CostId");

            migrationBuilder.RenameColumn(
                name: "AccountTypeId",
                table: "Transactions",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ItemTypeId",
                table: "Transactions",
                newName: "IX_Transactions_ReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CostTypeId",
                table: "Transactions",
                newName: "IX_Transactions_CostId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountTypeId",
                table: "Transactions",
                newName: "IX_Transactions_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "GeneralTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_CostId",
                table: "Transactions",
                column: "CostId",
                principalTable: "GeneralTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_ReasonId",
                table: "Transactions",
                column: "ReasonId",
                principalTable: "GeneralTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_CostId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GeneralTypes_ReasonId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ReasonId",
                table: "Transactions",
                newName: "ItemTypeId");

            migrationBuilder.RenameColumn(
                name: "CostId",
                table: "Transactions",
                newName: "CostTypeId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transactions",
                newName: "AccountTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ReasonId",
                table: "Transactions",
                newName: "IX_Transactions_ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CostId",
                table: "Transactions",
                newName: "IX_Transactions_CostTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                newName: "IX_Transactions_AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_AccountTypeId",
                table: "Transactions",
                column: "AccountTypeId",
                principalTable: "GeneralTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_CostTypeId",
                table: "Transactions",
                column: "CostTypeId",
                principalTable: "GeneralTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GeneralTypes_ItemTypeId",
                table: "Transactions",
                column: "ItemTypeId",
                principalTable: "GeneralTypes",
                principalColumn: "Id");
        }
    }
}
