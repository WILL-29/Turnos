using Microsoft.EntityFrameworkCore;
namespace Turnos.Models
{
    public class TurnosConext : DbContext
    {
        public TurnosConext(DbContextOptions<TurnosConext> opciones)
        : base(opciones)
        {
        }        
        public DbSet<Especialidad> Especialidades{get; set;}
    }
}