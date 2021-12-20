using Microsoft.EntityFrameworkCore.Migrations;

namespace Eroski.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EroskiItems",
                columns: table => new
                {
                    Seccion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    numeroTicket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EroskiItems", x => x.Seccion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EroskiItems");
        }
    }
}
