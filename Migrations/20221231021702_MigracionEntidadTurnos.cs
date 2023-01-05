using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigracionEntidadTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IDTurno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMedico = table.Column<int>(nullable: false),
                    IDPaciente = table.Column<int>(nullable: false),
                    HoraInic = table.Column<DateTime>(nullable: false),
                    HoraFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.IDTurno);
                    table.ForeignKey(
                        name: "FK_Turnos_Medicos_IDMedico",
                        column: x => x.IDMedico,
                        principalTable: "Medicos",
                        principalColumn: "ID_Medico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_Pacientes_IDPaciente",
                        column: x => x.IDPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "ID_Paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IDMedico",
                table: "Turnos",
                column: "IDMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IDPaciente",
                table: "Turnos",
                column: "IDPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");
        }
    }
}
