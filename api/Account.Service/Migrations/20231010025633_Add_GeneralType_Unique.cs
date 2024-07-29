using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Service.Migrations
{
    /// <inheritdoc />
    public partial class Add_GeneralType_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GeneralTypes_Category_Title",
                table: "GeneralTypes",
                columns: new[] { "Category", "Title" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GeneralTypes_Category_Title",
                table: "GeneralTypes");
        }
    }
}
