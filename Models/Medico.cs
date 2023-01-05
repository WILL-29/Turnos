using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int ID_Medico { get; set; }
        [Required (ErrorMessage = "Debe introducir un nombre")]
        public string Nombre { get; set; }
        [Required (ErrorMessage = "Debe introducir un apellido")]
        public string Apellido { get; set; }
        [Required (ErrorMessage = "Debe introducir una dirección")]
        [Display (Name = "Dirección")]
        public string Direccion { get; set; }
        [Required (ErrorMessage = "Debe introducir un número de teléfono")]
        public string Tel { get; set; }
        [Required (ErrorMessage = "Debe introducir correo")]
        [EmailAddress (ErrorMessage ="El correo introducido no es válido")]
        public string Email { get; set; }

        [Display (Name ="Horario Desde", Prompt = "Digite el horario")]
        [DataType (DataType.Time)]
        [DisplayFormat (DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioDesde { get; set; }

        [Display (Name ="Horario Desde", Prompt = "Digite el horario")]
        [DataType (DataType.Time)]
        [DisplayFormat (DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioHasta { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public List<Turno> Turno {get; set;}
    }
}