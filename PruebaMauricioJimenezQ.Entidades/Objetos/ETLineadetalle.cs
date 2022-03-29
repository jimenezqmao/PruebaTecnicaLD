using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMauricioJimenezQ.Entidades
{
    public class ETLineadetalle
    {
        public Guid     LineadetalleId      { get; set; }
        public Guid     FacturaId	        { get; set; }
        public Guid     ArticuloId	        { get; set; }
        public string   NombreArticulo      { get; set; }
        public decimal  PrecioUnitario      { get; set; }
        public int      Cantidad            { get; set; }
        public decimal  TotalLinea          { get; set; }
    }                   		
}
