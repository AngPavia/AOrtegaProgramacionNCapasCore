using System;
using System.Collections.Generic;

namespace DL
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdTipoPago { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
