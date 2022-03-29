using PruebaMauricioJimenezQ.PaginaWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMauricioJimenezQ.PaginaWeb.Controllers
{
    public class ClientesController : Controller
    {
        Service1Client ServicioTienda = new Service1Client();
        HomeController Home = new HomeController();

        public ActionResult ClienteCrear(int Codigo, int Identificacion, string Nombre)
        {
            try
            {
                ServicioTienda.RegistrarCliente(Codigo, Identificacion, Nombre);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult ClienteActualizar(string ClienteId, int Codigo, int Identificacion, string Nombre)
        {
            try
            {
                ServicioTienda.ActualizarCliente(ClienteId, Codigo, Identificacion, Nombre);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult ClienteEliminar(string ClienteId)
        {
            try
            {
                ServicioTienda.EliminarCliente(ClienteId);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }
    }
}
