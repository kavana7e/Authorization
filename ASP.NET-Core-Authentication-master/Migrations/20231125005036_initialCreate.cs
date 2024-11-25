using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_Core_Authentication.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersID = table.Column<int>(type: "int", nullable: false),
                    ChildID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Family_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Family_Parent_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Parent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Child",
                columns: new[] { "ID", "Birthday", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Anderson" },
                    { 2, new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", "Anderson" },
                    { 3, new DateTime(2018, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leighton", "Topaz" },
                    { 4, new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sasha", "Mathers" },
                    { 5, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Braydon", "Blossom" },
                    { 6, new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Levon", "Anderson" },
                    { 7, new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sage", "Goldstein" },
                    { 8, new DateTime(2018, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosemary", "Goldstein" },
                    { 9, new DateTime(2018, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thyme", "Goldstein" },
                    { 10, new DateTime(2018, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcus", "Blossom" }
                });

            migrationBuilder.InsertData(
                table: "Parent",
                columns: new[] { "ID", "Address", "City", "Email", "FirstName", "LastName", "MobilePhone", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "100 Oak Ave", "Traverse City", "", "Becky", "Bozwell", "(231)123-4567", "MI", "49696" },
                    { 2, "2010 Greenway Ave, Apt 202", "Traverse City", "", "Albert", "Anderson", "(231)123-4444", "MI", "49696" },
                    { 3, "1600 Park Place", "Traverse City", "", "Taylor", "Topaz", "(231)123-9874", "MI", "49696" },
                    { 4, "2 Flowing Park Drive", "Traverse City", "", "Magnolia", "Blossom", "(231)123-1111", "MI", "49696" },
                    { 5, "1950 Beaver Drive", "Traverse City", "", "Jerry", "Mathers", "(231)123-4433", "MI", "49696" },
                    { 6, "6 Hwy 5", "Traverse City", "", "Pepper", "Goldstein", "(231)123-6898", "MI", "49696" }
                });

            migrationBuilder.InsertData(
                table: "Family",
                columns: new[] { "ID", "ChildID", "MembersID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 6, 2 },
                    { 5, 3, 3 },
                    { 6, 4, 5 },
                    { 7, 5, 4 },
                    { 8, 10, 4 },
                    { 9, 7, 6 },
                    { 10, 8, 6 },
                    { 11, 9, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Family_ChildID",
                table: "Family",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Family_MembersID",
                table: "Family",
                column: "MembersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Parent");
        }
    }
}
