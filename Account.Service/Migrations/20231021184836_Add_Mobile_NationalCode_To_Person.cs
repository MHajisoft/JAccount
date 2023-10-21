using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Service.Migrations
{
    /// <inheritdoc />
    public partial class Add_Mobile_NationalCode_To_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Persons",
                type: "char(11)",
                unicode: false,
                fixedLength: true,
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Persons",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NationalCode",
                table: "Persons",
                column: "NationalCode",
                filter: "NationalCode IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_NationalCode",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Persons");
        }
    }
}
