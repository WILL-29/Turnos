using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;
using System.Linq;
using System.Threading.Tasks;
namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _contexto;
        public EspecialidadController(TurnosContext Contexto)
        {
            _contexto = Contexto;
        }
        // Esto es un Action (método que devuelve un IActionResult), los métodos siempre devuelven una vista con su mismo nombre (también puedes enviar información a la Vista),
        //por ejemplo este devuelve la vista Index (Las vistas de este controlador están en la carpeta con su nombre, dentro de la carpeta View. (View\Especialidad))
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Especialidades.ToListAsync());
            //La prueba de abajo, solo la hice para probar y funcionó como esperaba
            //return View(_contexto.Especialidades.ToList().Where(w => w.Descripcion == "Pediatria"));
        }
        //En este caso usamos el ? para convertir int en nulleable
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = await _contexto.Especialidades.FindAsync(id);
            if (especialidad == null) //Esta validación es por si nos pasan el parámetro, pero este ID no existe en la base de datos
            {
                return NotFound();
            }
            return View(especialidad);
        }
        //Con Http Post indicamos que este método, envía info
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Especialidad,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.ID_Especialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid == true)
            {
                _contexto.Update(especialidad);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
        //Este es tipo GET, este método solo obtiene información de lo que se va a eliminar y confirma su existencia, este no realiza ningún cambio
        public async Task<IActionResult> Delete(int? id)
        {
                if (id == null)
                {               
                    return NotFound();
                }
            var especialidad = await _contexto.Especialidades.FirstOrDefaultAsync(w => w.ID_Especialidad == id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad); 
        }
        //Este Mëtodo es tipo POST, este es que hace el cambio
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidad = await _contexto.Especialidades.FirstOrDefaultAsync(w => w.ID_Especialidad == id);
            _contexto.Especialidades.Remove(especialidad);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}