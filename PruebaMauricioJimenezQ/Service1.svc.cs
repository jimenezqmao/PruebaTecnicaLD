using PruebaMauricioJimenezQ.Datos;
using PruebaMauricioJimenezQ.Entidades;
using System;
using System.Collections.Generic;

namespace PruebaMauricioJimenezQ
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        //      Clientes
        public void RegistrarCliente(int Codigo, int Identificacion, string Nombre)
        {
            DSCliente EntidadCliente = new DSCliente();
            EntidadCliente.RegistrarCliente(Codigo, Identificacion, Nombre);
        }
        public void ActualizarCliente(string ClienteID, int Codigo, int Identificacion, string Nombre)
        {
            DSCliente EntidadCliente = new DSCliente();
            EntidadCliente.ActualizarCliente(ClienteID, Codigo, Identificacion, Nombre);
        }
        public List<ETCliente> ObtenerClienteOClientes(string ClienteID)
        {
            List<ETCliente> ParametrosCliente = new List<ETCliente>();
            DSCliente EntidadCliente = new DSCliente();
            ParametrosCliente = EntidadCliente.ObtenerClientes(ClienteID);
            return ParametrosCliente;
        }
        public void EliminarCliente(string ClienteID)
        {
            DSCliente EntidadCliente = new DSCliente();
            EntidadCliente.EliminarCliente(ClienteID);
        }


        //      Articulos
        public void RegistrarArticulo(int Codigo, string Nombre, decimal Precio)
        {
            DSArticulo EntidadArticulo = new DSArticulo();
            EntidadArticulo.RegistrarArticulo(Codigo, Nombre, Precio);
        }
        public void ActualizarArticulo(string ArticuloID, int Codigo, string Nombre, decimal Precio)
        {
            DSArticulo EntidadArticulo = new DSArticulo();
            EntidadArticulo.ActualizarArticulo(ArticuloID, Codigo, Nombre, Precio);
        }
        public List<ETArticulo> ObtenerArticuloOArticulos(string ArticuloID)
        {
            List<ETArticulo> ParametrosArticulo = new List<ETArticulo>();
            DSArticulo EntidadArticulo = new DSArticulo();
            ParametrosArticulo = EntidadArticulo.ObtenerArticulos(ArticuloID);
            return ParametrosArticulo;
        }
        public void EliminarArticulo(string ArticuloID)
        {
            DSArticulo EntidadArticulo = new DSArticulo();
            EntidadArticulo.EliminarArticulo(ArticuloID);
        }


        //      Facturas
        public void RegistrarFactura(string ClienteId, decimal TotalFactura, bool Pago)
        {
            DSFactura EntidadFactura = new DSFactura();
            EntidadFactura.RegistrarFactura(ClienteId, TotalFactura, Pago);
        }
        public void ActualizarFactura(string FacturaId,  string ClienteId, decimal TotalFactura, bool Pago)
        {
            DSFactura EntidadFactura = new DSFactura();
            EntidadFactura.ActualizarFactura(FacturaId, ClienteId, TotalFactura, Pago);
        }
        public List<ETFactura> ObtenerFacturaOFacturas(string FacturaId, string ClienteId)
        {
            List<ETFactura> ParametrosFactura = new List<ETFactura>();
            DSFactura EntidadFactura = new DSFactura();
            ParametrosFactura = EntidadFactura.ObtenerFacturas(FacturaId, ClienteId);
            return ParametrosFactura;
        }
        public void EliminarFactura(string FacturaId)
        {
            DSFactura EntidadFactura = new DSFactura();
            EntidadFactura.EliminarFactura(FacturaId);
        }


        //      Lineas de detalle
        public void RegistrarLineadetalle(string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea)
        {
            DSLineadetalle EntidadLineaDetalle = new DSLineadetalle();
            EntidadLineaDetalle.RegistrarLineadetalle(FacturaId, ArticuloId, PrecioUnitario, Cantidad, TotalLinea);
        }
        public void ActualizarLineadetalle(string LineaDetalleId, string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea)
        {
            DSLineadetalle EntidadLineaDetalle = new DSLineadetalle();
            EntidadLineaDetalle.ActualizarLineadetalle(LineaDetalleId, FacturaId, ArticuloId, PrecioUnitario, Cantidad, TotalLinea);
        }
        public List<ETLineadetalle> ObtenerLineadetalleOLineadetalles(string FacturaId)
        {
            List<ETLineadetalle> ParametrosLineadetalle = new List<ETLineadetalle>();
            DSLineadetalle EntidadLineadetalle = new DSLineadetalle();
            ParametrosLineadetalle = EntidadLineadetalle.ObtenerLineadetalles(FacturaId);
            return ParametrosLineadetalle;
        }
        public void EliminarLineadetalle(string LineaDetalleId)
        {
            DSLineadetalle EntidadLineaDetalle = new DSLineadetalle();
            EntidadLineaDetalle.EliminarLineadetalle(LineaDetalleId);
        }
    }
}
