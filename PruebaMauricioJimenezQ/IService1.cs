using PruebaMauricioJimenezQ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PruebaMauricioJimenezQ
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        //      Clientes
        [OperationContract]
        void RegistrarCliente(int Codigo, int Identificacion, string Nombre);

        [OperationContract]
        void ActualizarCliente(string ClienteId, int Codigo, int Identificacion, string Nombre);

        [OperationContract]
        List<ETCliente> ObtenerClienteOClientes(string ClienteId);

        [OperationContract]
        void EliminarCliente(string ClienteId);


        //      Articulos
        [OperationContract]
        void RegistrarArticulo(int Codigo, string Nombre, decimal Precio);

        [OperationContract]
        void ActualizarArticulo(string ArticuloId, int Codigo, string Nombre, decimal Precio);

        [OperationContract]
        List<ETArticulo> ObtenerArticuloOArticulos(string ArticuloId);

        [OperationContract]
        void EliminarArticulo(string ArticuloId);


        //      Facturas
        [OperationContract]
        void RegistrarFactura(string ClienteId, decimal TotalFactura, bool Pago);

        [OperationContract]
        void ActualizarFactura(string FacturaId, string ClienteId, decimal TotalFactura, bool Pago);

        [OperationContract]
        List<ETFactura> ObtenerFacturaOFacturas(string FacturaId, string ClienteId);

        [OperationContract]
        void EliminarFactura(string FacturaId);


        //      Lineas de detalle
        [OperationContract]
        void RegistrarLineadetalle(string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea);

        [OperationContract]
        void ActualizarLineadetalle(string LineaDetalleId, string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea);

        [OperationContract]
        List<ETLineadetalle> ObtenerLineadetalleOLineadetalles(string FacturaId);

        [OperationContract]
        void EliminarLineadetalle(string LineadetalleId);
    }
}
