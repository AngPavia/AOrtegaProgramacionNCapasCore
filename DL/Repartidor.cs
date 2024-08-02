using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Repartidor
    {
        public Repartidor()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdRepartidor { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
