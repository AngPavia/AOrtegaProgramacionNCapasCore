using System;
using System.Collections.Generic;

namespace DL
{
    public partial class ActualizacionPedido
    {
        public int IdActualizacionPedidos { get; set; }
        public int? IdPedido { get; set; }
        public int? IdEstadoPedido { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual EstadoPedido? IdEstadoPedidoNavigation { get; set; }
        public virtual Pedido? IdPedidoNavigation { get; set; }
    }
}
