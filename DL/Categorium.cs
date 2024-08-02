﻿using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Categorium
    {
        public Categorium()
        {
            SubCategoria = new HashSet<SubCategorium>();
        }

        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<SubCategorium> SubCategoria { get; set; }
    }
}
