using Ferreteria.BD;
using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class VentaController : Controller
    {
        // GET: Usuario
        DBFerre context = new DBFerre();
        List<Venta> datos = new List<Venta>();
        public ActionResult IndexV()   //int query
        {


            //if (query < 0)
            datos = context.Ventas.ToList();
            //else
            //    datos = context.Ventas.Where(o => o.IdVenta.Contains(query)).ToList();

            return View(datos);
        }

        public ActionResult CrearV()
        {
            var datosU = context.Usuarios.ToList();
            ViewBag.ListaU = datosU;




            return View();
        }

        public ActionResult Guardar(Venta venta )
        {

            context.Ventas.Add(venta);
            context.SaveChanges();

            return RedirectToAction("IndexV");
        }

        public ActionResult DetalleV(int id)
        {


            var ventas = context.Ventas.Where(o => o.Id == id).First();

            return View(ventas);
        }

        public ActionResult EditarV(int id)
        {
            var ventas = context.Ventas.Where(o => o.Id == id).First();

            return View(ventas);
        }

        public ActionResult Actualizar(int id, Venta ventaFormulario)
        {


            var ventaDb = context.Ventas.Where(o => o.Id == id).First();

            ventaDb.CodigoV = ventaFormulario.CodigoV;
            ventaDb.FechaV = ventaFormulario.FechaV;
            ventaDb.IdUsuario = ventaFormulario.IdUsuario;
            ventaDb.Productos = ventaFormulario.Productos;
            

            context.SaveChanges();

            return RedirectToAction("IndexV");
        }


        public ActionResult Eliminar(int id)
        {


            var ventaDb = context.Ventas.Where(o => o.Id == id).First();

            context.Ventas.Remove(ventaDb);

            context.SaveChanges();

            return RedirectToAction("IndexV");
        }
    }

}