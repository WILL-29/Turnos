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
        public IActionResult Edit(int? id)
        //En este caso usamos el ? para convertir int en nulleable
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = _contexto.Especialidades.Find(id);
            
            if (especialidad == null) //Esta validación es por si nos pasan el parámetro, pero este ID no existe en la base de datos
            {
                return NotFound();
            }
            return View(especialidad);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id_Especialidad,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.ID_Especialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid == true)
            {
                _contexto.Update(especialidad);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
    }
}