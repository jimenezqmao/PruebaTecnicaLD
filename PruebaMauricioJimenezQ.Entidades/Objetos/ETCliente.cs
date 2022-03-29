using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMauricioJimenezQ.Entidades
{
    public class ETCliente
    {
        public Guid     ClienteId       { get; set; }
        public int      Codigo          { get; set; }
	    public int      Identificacion  { get; set; }
        public string   Nombre          { get; set; }
    }
}
