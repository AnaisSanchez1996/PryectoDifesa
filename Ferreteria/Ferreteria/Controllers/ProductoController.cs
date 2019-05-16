using Ferreteria.BD;
using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Usuario
        DBFerre context = new DBFerre();
        List<Producto> datos = new List<Producto>();
        public ActionResult IndexP(string query)
        {


            if (query == null || query == "")
                datos = context.Productos.ToList();
            else
                datos = context.Productos.Where(o => o.NombreP.Contains(query)).ToList();

            return View(datos);
        }

        public ActionResult CrearP()
        {
            var datosL = context.Locals.ToList();
            ViewBag.Local = datosL;




            return View();
        }

        public ActionResult Guardar(Producto producto)
        {

            context.Productos.Add(producto);
            context.SaveChanges();

            return RedirectToAction("IndexP");
        }

        public ActionResult DetalleP(int id)
        {


            var producto = context.Productos.Where(o => o.Id == id).First();

            return View(producto);
        }

        public ActionResult EditarP(int id)
        {
            var datosL = context.Locals.ToList();
            ViewBag.Local = datosL;

            var producto = context.Productos.Where(o => o.Id == id).First();

            return View(producto);
        }

        public ActionResult Actualizar(int id, Producto productoFormulario)
        {


            var productoDb = context.Productos.Where(o => o.Id == id).First();

            productoDb.Codigo = productoFormulario.Codigo;
            productoDb.NombreP = productoFormulario.NombreP;
            productoDb.Stock = productoFormulario.Stock;
            productoDb.Precio = productoFormulario.Precio;
            productoDb.IdLocal = productoFormulario.IdLocal;

            context.SaveChanges();

            return RedirectToAction("IndexP");
        }


        public ActionResult Eliminar(int id)
        {


            var productoDb = context.Productos.Where(o => o.Id == id).First();

            context.Productos.Remove(productoDb);

            context.SaveChanges();

            return RedirectToAction("IndexP");
        }

    }
}