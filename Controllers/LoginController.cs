using Microsoft.AspNetCore.Mvc;
using Turnos.Models;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Turnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurnosContext _contexto;
        public LoginController(TurnosContext context)
        {
            _contexto = context;
        }

        public IActionResult Index() => View();

        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //Encriptar Password
                string PasswordEncriptada  = Encriptar(login.Password);
                var loginUsuario = _contexto.Login.Where(l => l.Usuario == login.Usuario && l.Password == PasswordEncriptada).FirstOrDefault();
                
                if (loginUsuario != null)
                {
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["errorLogin"] = "Las credenciales ingresadas son incorrectas.";
                    return View("Index");
                }

            }
            return View("Index");
        }
        public string Encriptar(string password)
        {
            //SHA256 objeto = new SHA256();
            using (SHA256 sha256hash = SHA256.Create()) //aquí solo estamos instanciando el objeto sha256hash
            {
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}