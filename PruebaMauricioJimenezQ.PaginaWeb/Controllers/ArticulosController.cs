using PruebaMauricioJimenezQ.PaginaWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMauricioJimenezQ.PaginaWeb.Controllers
{
    public class ArticulosController : Controller
    {
        Service1Client ServicioTienda = new Service1Client();
        HomeController Home = new HomeController();

        public ActionResult ArticuloCrear(int Codigo, string Nombre, decimal Precio)
        {
            try
            {
                ServicioTienda.RegistrarArticulo(Codigo, Nombre, Precio);
                Home.Mantenimientoarticulos();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult ArticuloActualizar(string ArticuloId, int Codigo, string Nombre, decimal Precio)
        {
            try
            {
                ServicioTienda.ActualizarArticulo(ArticuloId, Codigo, Nombre, Precio);
                Home.Mantenimientoarticulos();
                return View();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult ArticuloEliminar(string ArticuloId)
        {
            try
            {
                ServicioTienda.EliminarArticulo(ArticuloId);
                Home.Mantenimientoarticulos();
                return View();
            }
            catch (Exception)
            { }
            return View();
        }
    }
}
