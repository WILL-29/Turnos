using Microsoft.EntityFrameworkCore;
namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones)
        : base(opciones)
        {
        }        
        public DbSet<Especialidad> Especialidades{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidades");
                
                entidad.HasKey("ID_Especialidad");

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });
        }
    }
}