using PruebaMauricioJimenezQ.PaginaWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMauricioJimenezQ.PaginaWeb.Controllers
{
    public class LineasdetalleController : Controller
    {
        Service1Client ServicioTienda = new Service1Client();

        public ActionResult LineadetalleCrear(string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea)
        {
            try
            {
                ServicioTienda.RegistrarLineadetalle(FacturaId, ArticuloId, PrecioUnitario, Cantidad, TotalLinea);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult LineadetalleActualizar(string LineaDetalleId, string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea)
        {
            try
            {
                ServicioTienda.ActualizarLineadetalle(LineaDetalleId, FacturaId, ArticuloId, PrecioUnitario, Cantidad, TotalLinea);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult LineadetalleEliminar(string LineaDetalleId)
        {
            try
            {
                ServicioTienda.EliminarLineadetalle(LineaDetalleId);
                return View();
            }
            catch (Exception)
            { }
            return View();
        }
    }
}
