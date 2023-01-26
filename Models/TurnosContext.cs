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
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes {get; set;}
        public DbSet<MedicoEspecialidad> MedicoEspecialidad {get; set;}
        public DbSet<Turno> Turnos {get; set;}
        public DbSet<Login> Login {get; set;}
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
            
            // Esta es la tabla que guarda la relación de médico y especialidad
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new {x.ID_Medico, x.ID_Especialidad});

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(e => e.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.ID_Medico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(e => e.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.ID_Especialidad);     

            //Detalles de tabla para almacenar los turnos

            //Quiero que tenga un nombre personalizado
            modelBuilder.Entity<Turno>(entidad => {entidad.ToTable("Turnos");});

            //Esto para establecer la relación con la entidad paciente
            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
            .WithMany(p => p.Turno)//Esto quiere decir que un paciente podrá tener varios turnos, si te fijas la entidad PACIENTE los turnos se almacenan en una lista, por esto la relación es de uno a muchos
            .HasForeignKey(p => p.ID_Paciente); //Este es el campo de la tabla Turno que se usará como foreing key (este es el que se relacionará con Paciente)

            modelBuilder.Entity<Turno>().HasOne( x => x.Medico)
            .WithMany(p => p.Turno)
            .HasForeignKey(p => p.ID_Medico);   

            //Entidad Login
            modelBuilder.Entity<Login>(entidad=>{
                entidad.ToTable("Login");
                entidad.HasKey(c => c.ID_Login);
                entidad.Property(c => c.Usuario).IsRequired();
                entidad.Property(c=>c.Password).IsRequired();
            });
        }        
    }
}