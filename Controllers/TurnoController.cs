using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering; //Esta referencia es necesaria para SelectListo en Index
using System.Linq;
using Turnos.Models;
using System.Collections.Generic;
using System;

 
namespace Turnos.Models
{
    public class TurnoController : Controller
    {
        private readonly TurnosContext _contexto;
        private readonly IConfiguration _configuracion;

        public TurnoController(TurnosContext context, IConfiguration configuracion)
        {
            _contexto = context;
            _configuracion = configuracion;
        }
        public IActionResult Index()
        {
            ViewData["ID_Medico"] = new SelectList((from medico in _contexto.Medicos.ToList() select new { ID_Medico = medico.ID_Medico, NombreCompleto = medico.Nombre + " " + medico.Apellido}), "ID_Medico","NombreCompleto");
            ViewData["ID_Paciente"] = new SelectList((from paciente in _contexto.Pacientes.ToList() select new {ID_Paciente = paciente.ID_Paciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido}), "ID_Paciente","NombreCompleto");
            return View();
        }

        //Método para obtener Turnos de un médico
        public JsonResult ObtenerTurnos(int ID_Medico)
        {
            var Turnos = _contexto.Turnos.Where(t => t.ID_Medico == ID_Medico)
            .Select(t => new {
                t.ID_Turno,
                t.ID_Medico,
                t.ID_Paciente,
                t.HoraInic,
                t.HoraFin,
                PacienteNombreCompleto = t.Paciente.Nombre + " " + t.Paciente.Apellido })
            .ToList();
            //var Turnos = new List<Turno>();
            //Turnos = _contexto.Turnos.Where(t => t.ID_Medico == ID_Medico).ToList();
            return Json(Turnos); //esto convierte automáticamente la colección de turnos en un Json
        }

        //Grabar un turno
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;
            try
            {
                _contexto.Turnos.Add(turno);
                _contexto.SaveChanges();
                ok = true;
            }
            catch (Exception e)
            {                
                Console.WriteLine("{0} Excepción encontrada", e);
            }
            var JsonResult = new {ok = ok};
            return Json(JsonResult);
        }
        //Eliminar un turno
        public JsonResult EliminarTurno(int ID_Turno)
        {
            var ok = false;
            try
            {
                var TurnoEliminar = _contexto.Turnos.Where(t => t.ID_Turno == ID_Turno).FirstOrDefault();
                _contexto.Turnos.Remove(TurnoEliminar);
                _contexto.SaveChanges();
                ok = true;
            }
            catch (Exception e)
            {
                    Console.WriteLine("{0} Excepción encontrada",e);
            }
            var JsonResult = new {ok = ok};
            return Json(JsonResult);
        }

    }
}