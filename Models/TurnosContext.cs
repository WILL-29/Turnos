using Microsoft.EntityFrameworkCore;
using Turnos.Models;
namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones)
        : base(opciones)
        {
        }        
        public DbSet<Especialidad> Especialidades {get; set;}
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Pacientes {get; set;}
        public DbSet<MedicoEspecialidad> MedicoEspecialidad {get; set;}
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
            modelBuilder.Entity<Paciente>(entidad=> {
                entidad.ToTable("Pacientes");

                entidad.HasKey(p => p.ID_Paciente);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Medico>( entidad=> {
                entidad.ToTable("Medicos");
                entidad.HasKey(p => p.ID_Medico);
                
                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
                
                entidad.Property(p => p.Tel)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entidad.Property(p => p.HorarioDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(p => p.HorarioHasta)
                .IsRequired()
                .IsUnicode(false);
            });
            
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new {x.ID_Medico, x.ID_Especialidad});

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(e => e.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.ID_Medico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(e => e.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.ID_Especialidad);
            
            
            
            
        }

        
    }
}