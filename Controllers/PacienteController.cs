using Turnos.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _contexto;

        public PacienteController(TurnosContext Contexto)
        {
            _contexto = Contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Pacientes.ToListAsync());
        }
    }
}