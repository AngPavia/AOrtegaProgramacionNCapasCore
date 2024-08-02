using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Direccion
    {
        public Direccion()
        {
            Pedidos = new HashSet<Pedido>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdDireccion { get; set; }
        public string? Calle { get; set; }
        public string? NumeroInterior { get; set; }
        public string? NumeroExterior { get; set; }
        public int? IdColonia { get; set; }

        public virtual Colonium? IdColoniaNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
