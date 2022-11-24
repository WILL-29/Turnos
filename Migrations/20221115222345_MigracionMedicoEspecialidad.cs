using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigracionMedicoEspecialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origen",
                table: "Especialidades");

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    ID_Medico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Tel = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    HorarioDesde = table.Column<DateTime>(unicode: false, nullable: false),
                    HorarioHasta = table.Column<DateTime>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.ID_Medico);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidad",
                columns: table => new
                {
                    Id_Medico = table.Column<int>(nullable: false),
                    Id_Especialidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidad", x => new { x.Id_Medico, x.Id_Especialidad });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Especialidades_Id_Especialidad",
                        column: x => x.Id_Especialidad,
                        principalTable: "Especialidades",
                        principalColumn: "ID_Especialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Medicos_Id_Medico",
                        column: x => x.Id_Medico,
                        principalTable: "Medicos",
                        principalColumn: "ID_Medico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidad_Id_Especialidad",
                table: "MedicoEspecialidad",
                column: "Id_Especialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoEspecialidad");

            migrationBuilder.DropTable(
                name: "Medicos");

            //migrationBuilder.AddColumn<string>(
            //    name: "Origen",
            //    table: "Especialidades",
            //    type: "nvarchar(max)",
            //    nullable: true);
        }
    }
}
