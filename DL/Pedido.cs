using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Pedido
    {
        public Pedido()
        {
            ActualizacionPedidos = new HashSet<ActualizacionPedido>();
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int IdPedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdSucursal { get; set; }
        public int? IdTipoPago { get; set; }
        public int? IdDireccion { get; set; }
        public int? IdEstadoPedido { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? IdRepartido { get; set; }

        public virtual Direccion? IdDireccionNavigation { get; set; }
        public virtual EstadoPedido? IdEstadoPedidoNavigation { get; set; }
        public virtual Repartidor? IdRepartidoNavigation { get; set; }
        public virtual Sucursal? IdSucursalNavigation { get; set; }
        public virtual TipoPago? IdTipoPagoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<ActualizacionPedido> ActualizacionPedidos { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
