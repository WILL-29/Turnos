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

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id== null)
            {
                return NotFound();
            }
            var paciente = await _contexto.Pacientes.FirstOrDefaultAsync(p => p.ID_Paciente == Id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Paciente,Nombre,Apellido,Direccion,Telefono,Email")]Paciente paciente)
        {
            if (ModelState.IsValid)
            {
            _contexto.Pacientes.Add(paciente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}