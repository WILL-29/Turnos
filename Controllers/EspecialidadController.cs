using Microsoft.AspNetCore.Mvc;
using Turnos.Models;
using System.Linq;
namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _contexto;
        public EspecialidadController(TurnosContext Contexto)
        {
            _contexto = Contexto;
        }
        public IActionResult Index()
        {
            return View(_contexto.Especialidades.ToList());
        }
    }
}