using Ferreteria.BD;
using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class LocalController : Controller
    {
        // GET: Usuario
        DBFerre context = new DBFerre();
        List<Local> datos = new List<Local>();
        public ActionResult IndexL(string query)
        {


            if (query == null || query == "")
                datos = context.Locals.ToList();
            else
                datos = context.Locals.Where(o => o.NLocal.Contains(query)).ToList();

            return View(datos);
        }

        //public ActionResult CrearL()
        //{
        //    var datosU = context.Usuarios.ToList();
        //    ViewBag.User = datosU;




        //    return View();
        //}

        //public ActionResult Guardar(Local local)
        //{

        //    context.Locals.Add(local);
        //    context.SaveChanges();

        //    return RedirectToAction("IndexL");
        //}

        [HttpGet]
        public ActionResult CrearL()
        {
            var datosU = context.Usuarios.ToList();
            ViewBag.ListaU = datosU;
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult CrearL(Local local)
        {
            var datosU = context.Usuarios.ToList();
            ViewBag.ListaU = datosU;

            context.Locals.Add(local);
            context.SaveChanges();
            return TablaLocal();

        }

        [HttpGet]
        public ActionResult TablaLocal()
        {

            var datos = context.Locals.ToList();

            return PartialView("TablaLocal", datos);
        }



        public ActionResult DetalleL(int id)
        {


            var locals = context.Locals.Where(o => o.Id == id).First();

            return View(locals);
        }

        public ActionResult EditarL(int id)
        {

            var datosU = context.Usuarios.ToList();
            ViewBag.User = datosU;
            var locals = context.Locals.Where(o => o.Id == id).First();

            return View(locals);
        }

        public ActionResult Actualizar(int id, Local localFormulario)
        {


            var localDb = context.Locals.Where(o => o.Id == id).First();

            localDb.NLocal = localFormulario.NLocal;
            localDb.Direccion = localFormulario.Direccion;
            localDb.Ciudad = localFormulario.Ciudad;
            localDb.NombreU = localFormulario.NombreU;


            context.SaveChanges();

            return RedirectToAction("IndexL");
        }


        public ActionResult Eliminar(int id)
        {


            var localDb = context.Locals.Where(o => o.Id == id).First();

            context.Locals.Remove(localDb);

            context.SaveChanges();

            return RedirectToAction("IndexL");
        }
    }
}