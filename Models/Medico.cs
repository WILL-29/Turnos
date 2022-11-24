using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int ID_Medico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime HorarioDesde { get; set; }
        public DateTime HorarioHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}