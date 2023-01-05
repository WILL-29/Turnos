using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int ID_Paciente {get; set;}
        [Required (ErrorMessage = "Debe introducir un nombre")]        
        public string Nombre {get; set;}
        [Required (ErrorMessage = "Debe introducir un apellido")]
        public string Apellido {get; set;}
        [Required (ErrorMessage = "Debe introducir una dirección")]
        public string Direccion {get; set;}
        [Required (ErrorMessage = "Debe introducir un número de teléfono")]
        public string Telefono {get; set;}
        [EmailAddress]
        [Required (ErrorMessage = "Debe introducir un correo")]        
        public string Email {get; set;}       
        public List<Turno> Turno { get; set; }     
    }
}