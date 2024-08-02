﻿using System;
using System.Collections.Generic;

namespace DL
{
    public partial class VwusuarioGetAll
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string ApellidoPaterno { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Curp { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public bool? Status { get; set; }
        public int? IdDireccion { get; set; }
        public string? Calle { get; set; }
        public string? NumeroExterior { get; set; }
        public string? NumeroInterior { get; set; }
    }
}
