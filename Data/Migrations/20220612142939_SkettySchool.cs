using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkettySchool.Migrations
{
    public partial class SkettySchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    PupilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.PupilId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassDescription", "ClassName" },
                values: new object[,]
                {
                    { 1, "I.T Class One", "I.T" },
                    { 2, "History Class One", "History" }
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "PupilId", "DateOfBirth", "FirstName", "LastName", "SchoolYear", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire", "Dearing", 7, "Pupil" },
                    { 2, new DateTime(1999, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim", "Murphey", 8, "Pupil" },
                    { 3, new DateTime(1999, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lex", "Murphey", 9, "Pupil" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "FirstName", "LastName", "UserType" },
                values: new object[,]
                {
                    { 1, "Alan", "Grant", "Teacher" },
                    { 2, "Ellie", "Sattler", "Teacher" },
                    { 3, "Ian", "Malcom", "Teacher" },
                    { 4, "Owen", "Grady", "Teacher" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
