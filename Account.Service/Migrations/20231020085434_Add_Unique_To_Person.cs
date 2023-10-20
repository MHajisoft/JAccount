using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Service.Migrations
{
    /// <inheritdoc />
    public partial class Add_Unique_To_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Persons_FirstName_LastName_FatherId",
                table: "Persons",
                columns: new[] { "FirstName", "LastName", "FatherId" },
                unique: true,
                filter: "FatherId IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FirstName_LastName_RelativeId",
                table: "Persons",
                columns: new[] { "FirstName", "LastName", "RelativeId" },
                unique: true,
                filter: "RelativeId IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_FirstName_LastName_FatherId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_FirstName_LastName_RelativeId",
                table: "Persons");
        }
    }
}
