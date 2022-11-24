using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int ID_Especialidad {get; set;}
        public string Descripcion {get; set;}
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
    
}