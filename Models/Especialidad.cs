using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int ID_Especialidad {get; set;}
        [StringLength (200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        [Required (ErrorMessage = "Este campo es requerido")]        
        [Display (Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string Descripcion {get; set;}
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
    
}