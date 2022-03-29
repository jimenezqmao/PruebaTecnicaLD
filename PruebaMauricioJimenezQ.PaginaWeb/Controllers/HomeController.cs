using PruebaMauricioJimenezQ.PaginaWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaMauricioJimenezQ.PaginaWeb.Controllers
{
    public class HomeController : Controller
    {
        Service1Client ServicioTienda = new Service1Client();

        public ActionResult Mantenimientoclientes()
        {
            try
            {
                var ParametrosCliente = ServicioTienda.ObtenerClienteOClientes(null);
                ViewBag.Conteo = ParametrosCliente.Count();
                ViewBag.Datos = ParametrosCliente;
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult Mantenimientoarticulos()
        {
            try
            {
                var ParametrosCliente = ServicioTienda.ObtenerArticuloOArticulos(null);
                ViewBag.Conteo = ParametrosCliente.Count();
                ViewBag.Datos = ParametrosCliente;
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult Facturacion()
        {
            try
            {
                var ParametrosCliente = ServicioTienda.ObtenerClienteOClientes(null);
                var ParametrosFacturas = ServicioTienda.ObtenerFacturaOFacturas(null,null);
                ViewBag.ConteoClientes = ParametrosCliente.Count();
                ViewBag.ConteoFacturas = ParametrosFacturas.Count();
                ViewBag.DatosClientes = ParametrosCliente;
                ViewBag.DatosFacturas = ParametrosFacturas;
            }
            catch (Exception)
            { }
            return View();
        }

        public ActionResult Lineasdetalle(string FacturaId, string ClienteId)
        {
            try
            {
                var ParametrosArticulo = ServicioTienda.ObtenerArticuloOArticulos(null);
                var ParametrosCliente = ServicioTienda.ObtenerClienteOClientes(ClienteId);
                var ParametrosFactura = ServicioTienda.ObtenerFacturaOFacturas(FacturaId, ClienteId);
                var ParametrosLineaDetalle = ServicioTienda.ObtenerLineadetalleOLineadetalles(FacturaId);
                ViewBag.Conteo = ParametrosLineaDetalle.Count();
                ViewBag.ConteoArticulo = ParametrosArticulo.Count();
                ViewBag.DatosArticulo = ParametrosArticulo;
                ViewBag.DatosCliente = ParametrosCliente;
                ViewBag.DatosFactura = ParametrosFactura;
                ViewBag.DatosLineasDetalle = ParametrosLineaDetalle;

            }
            catch (Exception)
            { }
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}