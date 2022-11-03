using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP01_21_22_TURNO_02.Migrations
{
    public partial class FirstStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contracapa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.ISBN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
