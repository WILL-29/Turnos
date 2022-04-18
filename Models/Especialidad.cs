using System.ComponentModel.DataAnnotations;
namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int ID_Especialidad {get; set;}
        public string Descripcion {get; set;}
        public string Origen {get; set;}
    }
    
}