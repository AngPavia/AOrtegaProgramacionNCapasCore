using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Estado
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
        }

        public byte IdEstado { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
