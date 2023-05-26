using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieFan.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieIMDB = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDirector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieActors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "MovieActors", "MovieDescription", "MovieDirector", "MovieDuration", "MovieIMDB", "MovieName", "ReleaseDate" },
                values: new object[] { 1, "Behzad", "Flutter", "Google", "99 min", 9.9000000000000004, "Computer Engeenering 1", new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "MovieActors", "MovieDescription", "MovieDirector", "MovieDuration", "MovieIMDB", "MovieName", "ReleaseDate" },
                values: new object[] { 2, "Behzad", "DotNet", "Microsoft", "99 min", 9.5999999999999996, "Computer Engeenering 2", new DateTime(2006, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "MovieActors", "MovieDescription", "MovieDirector", "MovieDuration", "MovieIMDB", "MovieName", "ReleaseDate" },
                values: new object[] { 3, "Behzad", "Python", "Python Software Foundation", "99 min", 9.3000000000000007, "Computer Engeenering 3", new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
