using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            ProductoSucursals = new HashSet<ProductoSucursal>();
        }

        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public byte[]? Imagen { get; set; }
        public int? IdSubCategoria { get; set; }
        public int? IdCategoria { get; set; } = 0;
        public string? Categoria { get; set; }
        


        public virtual SubCategorium? IdSubCategoriaNavigation { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; }
    }
}
