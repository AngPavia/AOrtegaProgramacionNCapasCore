using System;
using System.Collections.Generic;

namespace DL
{
    public partial class SubCategorium
    {
        public SubCategorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdSubCategoria { get; set; }
        public string? Nombre { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
