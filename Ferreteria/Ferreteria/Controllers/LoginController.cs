using Ferreteria.BD;
using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ferreteria.Controllers
{
    public class LoginController : Controller
    {

        DBFerre conexion = new DBFerre();
        public ActionResult Ingreso(Usuario usuario)
        {
            int id = 0;

            //autentificar
            Usuario ValidarCuenta = null;
            try//valida si es cuenta de algun jefe de equipo
            {
                ValidarCuenta = conexion.Usuarios.Where(o => o.Correo == usuario.Correo && o.Password == usuario.Password).First();//no puede quedarse con null
                var objeto = conexion.Usuarios.Where(o => o.Correo == usuario.Correo && o.Password == usuario.Password).First();
                id = objeto.Id;
                Session["User"] = objeto.Id.ToString();
                Session["Nombres"] = objeto.Nombres.ToString();
                FormsAuthentication.SetAuthCookie(usuario.Correo, false);
            }
            catch (Exception)
            {
            }

            if (ValidarCuenta != null && id != 0)
            {
                return RedirectPermanent("/Usuario/IndexU?id=" + id);
            }
            return View("Ingreso");
        }

        public ActionResult Home() {



            return View();
        }


    }
}