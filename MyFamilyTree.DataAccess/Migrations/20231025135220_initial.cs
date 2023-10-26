using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFamilyTree.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonGender = table.Column<int>(type: "int", nullable: true),
                    LifespanInYears = table.Column<short>(type: "smallint", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PlaceOfDeath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PlaceOfLiving = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Parent1Id = table.Column<int>(type: "int", nullable: false),
                    Parent2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonPerson",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPerson", x => new { x.ChildrenId, x.ParentsId });
                    table.ForeignKey(
                        name: "FK_PersonPerson_PeopleCollection_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "PeopleCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPerson_PeopleCollection_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "PeopleCollection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCollection_Id",
                table: "PeopleCollection",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonPerson_ParentsId",
                table: "PersonPerson",
                column: "ParentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPerson");

            migrationBuilder.DropTable(
                name: "PeopleCollection");
        }
    }
}
