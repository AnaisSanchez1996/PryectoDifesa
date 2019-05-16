using Ferreteria.BD;
using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        DBFerre context = new DBFerre();
        List<Usuario> datos = new List<Usuario>();

        [HttpGet]
        public ActionResult IndexU(string query)
        {


            if (query == null || query == "")
                datos = context.Usuarios.ToList();
            else
                datos = context.Usuarios.Where(o => o.Nombres.Contains(query)).ToList();

            return View(datos);
        }



        //public ActionResult CrearU()
        //{
        //    var datosL = context.Locals.ToList();
        //    ViewBag.ListaL = datosL;
        //    return View();

        //}

        //public ActionResult Guardar(Usuario usuario)
        //{

        //    context.Usuarios.Add(usuario);
        //    context.SaveChanges();

        //    //return RedirectToAction("CrearU");
        //    return TablaPersonas();
        //}

        [HttpGet]
        public ActionResult CrearU()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult CrearU(Usuario usuario)
        {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            return RedirectToAction("IndexU");

        }

        [HttpGet]
        public ActionResult TablaUsuarios()
        {

            var datos = context.Usuarios.ToList();

            return PartialView("TablaUsuarios", datos);
        }


        public ActionResult DetalleU(int id)
        {


            var usuarios = context.Usuarios.Where(o => o.Id == id).First();

            return View(usuarios);
        }

        public ActionResult EditarU(int id)
        {
            var usuarios = context.Usuarios.Where(o => o.Id == id).First();

            return View(usuarios);
        }

        public ActionResult Actualizar(int id, Usuario usuarioFormulario)
        {


            var usuarioDb = context.Usuarios.Where(o => o.Id == id).First();

            usuarioDb.DNI = usuarioFormulario.DNI;
            usuarioDb.Nombres = usuarioFormulario.Nombres;
            usuarioDb.Apellidos = usuarioFormulario.Apellidos;
            usuarioDb.Correo = usuarioFormulario.Correo;
            usuarioDb.Telefono = usuarioFormulario.Telefono;
            usuarioDb.Password = usuarioFormulario.Password;

            context.SaveChanges();

            return RedirectToAction("IndexU");
        }


        public ActionResult Eliminar(int id)
        {


            var usuarioDb = context.Usuarios.Where(o => o.Id == id).First();

            context.Usuarios.Remove(usuarioDb);

            context.SaveChanges();

            return RedirectToAction("IndexU");
        }
    }
}