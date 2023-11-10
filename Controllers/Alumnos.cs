using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TrabajoFinalProgramacion.Models;

namespace TrabajoFinalProgramacion.Controllers
{

    [Authorize(Policy = "RequiereAutenticacion")]
    public class Alumnos : Controller
    {
        private readonly DblogContext _context;

        public Alumnos(DblogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var alumno = await _context.Alumnos.FirstOrDefaultAsync();
            TempData["indice"] = 0;
            return View(alumno);


        }

        public async Task<IActionResult> Siguiente()
        {

            ViewBag.nombre = TempData["nombreUsuario"];
            ViewBag.inicioSesion = true;
            ViewBag.session = true;

            var alumnos = await _context.Alumnos.ToListAsync();

            var indice = (int)TempData["indice"]! + 1;

            if (indice > alumnos.Count - 1)
            {
                indice = alumnos.Count - 1;
            }

            TempData["sesion"] = true;
            TempData["indice"] = indice;
            return View("Index", alumnos[indice]);

        }
        public async Task<IActionResult> Anterior()
        {


            ViewBag.nombre = TempData["nombreUsuario"];
            ViewBag.inicioSesion = true;
            ViewBag.session = true;

            var alumnos = await _context.Alumnos.ToListAsync();

            var indice = (int)TempData["indice"]! - 1;

            if (indice < 0)
            {
                indice = 0;
            }

            TempData["sesion"] = true;
            TempData["indice"] = indice;
            return View("Index", alumnos[indice]);




        }
        public async Task<IActionResult> PrimerAlumno()
        {

            ViewBag.nombre = TempData["nombreUsuario"];
            ViewBag.inicioSesion = true;
            ViewBag.session = true;

            var alumno = await _context.Alumnos.FirstOrDefaultAsync();
            TempData["sesion"] = true;
            TempData["indice"] = 0;
            return View("Index", alumno);


        }

        public async Task<IActionResult> UltimoAlumno()
        {

            ViewBag.nombre = TempData["nombreUsuario"];
            ViewBag.inicioSesion = true;
            ViewBag.session = true;

            var alumnos = await _context.Alumnos.ToListAsync();
            TempData["sesion"] = true;
            TempData["indice"] = alumnos.Count - 1;
            return View("Index", alumnos.Last());



        }




    }
}