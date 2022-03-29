using System;

namespace PruebaMauricioJimenezQ.Entidades
{
    public class ETArticulo
    {
        public Guid     ArticuloId      { get; set; }
        public int      Codigo          { get; set; }
        public string   Nombre          { get; set; }
        public decimal  Precio          { get; set; }
    }
}
