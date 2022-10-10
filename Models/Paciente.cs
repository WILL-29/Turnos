using System.ComponentModel.DataAnnotations;
namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int ID_Paciente {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public string Email {get; set;}
    }
}