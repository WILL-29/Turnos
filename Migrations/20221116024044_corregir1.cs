using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class corregir1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidad_Especialidades_Id_Especialidad",
                table: "MedicoEspecialidad");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidad_Medicos_Id_Medico",
                table: "MedicoEspecialidad");

            migrationBuilder.RenameColumn(
                name: "Id_Especialidad",
                table: "MedicoEspecialidad",
                newName: "ID_Especialidad");

            migrationBuilder.RenameColumn(
                name: "Id_Medico",
                table: "MedicoEspecialidad",
                newName: "ID_Medico");

            migrationBuilder.RenameIndex(
                name: "IX_MedicoEspecialidad_Id_Especialidad",
                table: "MedicoEspecialidad",
                newName: "IX_MedicoEspecialidad_ID_Especialidad");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidad_Especialidades_ID_Especialidad",
                table: "MedicoEspecialidad",
                column: "ID_Especialidad",
                principalTable: "Especialidades",
                principalColumn: "ID_Especialidad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidad_Medicos_ID_Medico",
                table: "MedicoEspecialidad",
                column: "ID_Medico",
                principalTable: "Medicos",
                principalColumn: "ID_Medico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidad_Especialidades_ID_Especialidad",
                table: "MedicoEspecialidad");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidad_Medicos_ID_Medico",
                table: "MedicoEspecialidad");

            migrationBuilder.RenameColumn(
                name: "ID_Especialidad",
                table: "MedicoEspecialidad",
                newName: "Id_Especialidad");

            migrationBuilder.RenameColumn(
                name: "ID_Medico",
                table: "MedicoEspecialidad",
                newName: "Id_Medico");

            migrationBuilder.RenameIndex(
                name: "IX_MedicoEspecialidad_ID_Especialidad",
                table: "MedicoEspecialidad",
                newName: "IX_MedicoEspecialidad_Id_Especialidad");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidad_Especialidades_Id_Especialidad",
                table: "MedicoEspecialidad",
                column: "Id_Especialidad",
                principalTable: "Especialidades",
                principalColumn: "ID_Especialidad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidad_Medicos_Id_Medico",
                table: "MedicoEspecialidad",
                column: "Id_Medico",
                principalTable: "Medicos",
                principalColumn: "ID_Medico",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
