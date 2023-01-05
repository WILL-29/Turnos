using System;
using System.ComponentModel.DataAnnotations;
namespace Turnos.Models
{
    public class Turno
    {
        [Key]
        public int ID_Turno { get; set; }
        public int ID_Medico { get; set; }
        public int ID_Paciente { get; set; }       
        public DateTime HoraInic { get; set; }
        public DateTime HoraFin { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }  
}