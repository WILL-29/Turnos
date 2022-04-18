using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigraMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    ID_Especialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Origen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.ID_Especialidad);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
