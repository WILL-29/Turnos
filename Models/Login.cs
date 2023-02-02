using System.ComponentModel.DataAnnotations;
namespace Turnos.Models
{
    public class Login
    {   
        [Key]
        public int ID_Login { get; set; }
        [Required (ErrorMessage = "Debe ingresar un usuario")]
        public string Usuario { get; set; }
        [Required (ErrorMessage = "Debe ingresar una contraseña")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}