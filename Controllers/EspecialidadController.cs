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

        // Esto es un Action (método que devuelve un IActionResult), los métodos siempre devuelven una vista con su mismo nombre (también puedes enviar información a la Vista),
        //por ejemplo este devuelve la vista Index (Las vistas de este controlador están en la carpeta con su nombre, dentro de la carpeta View. (View\Especialidad))
        public IActionResult Index()
        {

            return View(_contexto.Especialidades.ToList());

            //La prueba de abajo, solo la hice para probar y funcionó como esperaba
            //return View(_contexto.Especialidades.ToList().Where(w => w.Descripcion == "Pediatria"));
        }
       

        //En este caso usamos el ? para convertir int en nulleable
        public IActionResult Edit(int? id)
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

        //Con Http Post indicamos que este método, envía info
        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID_Especialidad,Descripcion")] Especialidad especialidad)
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


        //Este es tipo GET, este método solo obtiene información de lo que se va a eliminar y confirma su existencia, este no realiza ningún cambio
        public IActionResult Delete(int? id)
        {
                if (id == null)
                {               
                    return NotFound();
                }
            var especialidad = _contexto.Especialidades.FirstOrDefault(w => w.ID_Especialidad == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad); 
        }

        //Este Mëtodo es tipo POST, este es que hace el cambio
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var especialidad = _contexto.Especialidades.FirstOrDefault(w => w.ID_Especialidad == id);
            _contexto.Especialidades.Remove(especialidad);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}