using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public string UserName { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte? IdRol { get; set; }
        public string ApellidoPaterno { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Curp { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public int? IdDireccion { get; set; }
        public string? Imagen { get; set; }
        public bool? Status { get; set; }
        public int? Edad { get; set; }
        public string? IdAspNet { get; set; }

        public virtual AspNetUser? IdAspNetNavigation { get; set; }
        public virtual Direccion? IdDireccionNavigation { get; set; }
        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
