using System;
using System.Collections.Generic;

namespace DL
{
    public partial class EstadoPedido
    {
        public EstadoPedido()
        {
            ActualizacionPedidos = new HashSet<ActualizacionPedido>();
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEstadoPedido { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<ActualizacionPedido> ActualizacionPedidos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
