using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMauricioJimenezQ.Entidades
{
    public class ETFactura
    {
        public Guid     FacturaId       { get; set; }
        public Guid     ClienteId	    { get; set; }
        public string   NombreCliente   { get; set; }
        public int      Consecutivo	    { get; set; }
        public decimal  TotalFactura    { get; set; }
        public bool     Pago		    { get; set; }
    }
}
