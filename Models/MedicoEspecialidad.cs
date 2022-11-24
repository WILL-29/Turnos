namespace Turnos.Models
{
    public class MedicoEspecialidad
    {
        public int ID_Medico {get; set;}
        public int ID_Especialidad { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}