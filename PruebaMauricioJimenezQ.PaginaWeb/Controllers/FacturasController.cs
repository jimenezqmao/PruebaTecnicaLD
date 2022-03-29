using PruebaMauricioJimenezQ.PaginaWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMauricioJimenezQ.PaginaWeb.Controllers
{
    public class FacturasController : Controller
    {
        Service1Client ServicioTienda = new Service1Client();

        public ActionResult FacturaCrear(string ClienteId, decimal TotalFactura, bool Pago)
        {
            try
            {
                ServicioTienda.RegistrarFactura(ClienteId, TotalFactura, Pago);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult FacturaActualizar(string FacturaId, string ClienteId, decimal TotalFactura, bool Pago)
        {
            try
            {
                ServicioTienda.ActualizarFactura(FacturaId, ClienteId, TotalFactura, Pago);
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult FacturaEliminar(string FacturaId)
        {
            try
            {
                ServicioTienda.EliminarFactura(FacturaId);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }
    }
}
