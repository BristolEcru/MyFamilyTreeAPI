using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFamilyTree.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addedplaceofburialcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBurialCementary",
                table: "PeopleCollection",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceOfBurialCementary",
                table: "PeopleCollection");
        }
    }
}
