using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace WebAPI_MVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(4)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BNev = table.Column<string>(type: "varchar(40)", nullable: true),
                    Jelszo = table.Column<string>(type: "varchar(32)", nullable: true),
                    FNev = table.Column<string>(type: "varchar(60)", nullable: true),
                    Jog = table.Column<int>(type: "int(1)", nullable: false),
                    Aktiv = table.Column<int>(type: "int(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
