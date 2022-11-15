using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_App.Migrations.Director_App
{
    public partial class DirectorInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Award = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Director");
        }
    }
}
