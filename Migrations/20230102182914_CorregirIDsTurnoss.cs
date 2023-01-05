using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class CorregirIDsTurnoss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_IDMedico",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pacientes_IDPaciente",
                table: "Turnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turnos",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_IDMedico",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_IDPaciente",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "IDTurno",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "IDMedico",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "IDPaciente",
                table: "Turnos");

            migrationBuilder.AddColumn<int>(
                name: "ID_Turno",
                table: "Turnos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID_Medico",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID_Paciente",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turnos",
                table: "Turnos",
                column: "ID_Turno");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ID_Medico",
                table: "Turnos",
                column: "ID_Medico");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ID_Paciente",
                table: "Turnos",
                column: "ID_Paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_ID_Medico",
                table: "Turnos",
                column: "ID_Medico",
                principalTable: "Medicos",
                principalColumn: "ID_Medico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_ID_Paciente",
                table: "Turnos",
                column: "ID_Paciente",
                principalTable: "Pacientes",
                principalColumn: "ID_Paciente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_ID_Medico",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pacientes_ID_Paciente",
                table: "Turnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turnos",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ID_Medico",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ID_Paciente",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ID_Turno",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ID_Medico",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ID_Paciente",
                table: "Turnos");

            migrationBuilder.AddColumn<int>(
                name: "IDTurno",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDMedico",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDPaciente",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turnos",
                table: "Turnos",
                column: "IDTurno");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IDMedico",
                table: "Turnos",
                column: "IDMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IDPaciente",
                table: "Turnos",
                column: "IDPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_IDMedico",
                table: "Turnos",
                column: "IDMedico",
                principalTable: "Medicos",
                principalColumn: "ID_Medico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_IDPaciente",
                table: "Turnos",
                column: "IDPaciente",
                principalTable: "Pacientes",
                principalColumn: "ID_Paciente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
