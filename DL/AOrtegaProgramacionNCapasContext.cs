using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class AOrtegaProgramacionNCapasContext : DbContext
    {
        public AOrtegaProgramacionNCapasContext()
        {
        }

        public AOrtegaProgramacionNCapasContext(DbContextOptions<AOrtegaProgramacionNCapasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualizacionPedido> ActualizacionPedidos { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Colonium> Colonia { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;
        public virtual DbSet<DireccionSource> DireccionSources { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductoSucursal> ProductoSucursals { get; set; } = null!;
        public virtual DbSet<Repartidor> Repartidors { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<SubCategorium> SubCategoria { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<VwusuarioGetAll> VwusuarioGetAlls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=AOrtegaProgramacionNCapas;User ID=sa;Password=pass@word1;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActualizacionPedido>(entity =>
            {
                entity.HasKey(e => e.IdActualizacionPedidos)
                    .HasName("PK__Actualiz__F592112B4124C4BB");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.ActualizacionPedidos)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .HasConstraintName("FK__Actualiza__IdEst__2BFE89A6");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.ActualizacionPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__Actualiza__IdPed__2B0A656D");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleId");

                            j.HasIndex(new[] { "UserId" }, "IX_UserId");

                            j.IndexerProperty<string>("UserId").HasMaxLength(128);

                            j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10544C4C49");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colonium>(entity =>
            {
                entity.HasKey(e => e.IdColonia)
                    .HasName("PK__Colonia__A1580F667901405A");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Colonia)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__Colonia__IdMunic__2C3393D0");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido)
                    .HasName("PK__DetalleP__48AFFD95FCFEF13B");

                entity.ToTable("DetallePedido");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__DetallePe__IdPed__2EDAF651");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetallePe__IdPro__2FCF1A8A");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__Direccio__1F8E0C7695F62C2F");

                entity.ToTable("Direccion");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroExterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroInterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdColoniaNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdColonia)
                    .HasConstraintName("FK__Direccion__IdCol__2F10007B");
            });

            modelBuilder.Entity<DireccionSource>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DireccionSource");

                entity.Property(e => e.CCp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("c_CP");

                entity.Property(e => e.CCveCiudad).HasColumnName("c_cve_ciudad");

                entity.Property(e => e.CEstado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("c_estado");

                entity.Property(e => e.CMnpio)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("c_mnpio");

                entity.Property(e => e.COficina)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("c_oficina");

                entity.Property(e => e.CTipoAsenta).HasColumnName("c_tipo_asenta");

                entity.Property(e => e.DAsenta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("d_asenta");

                entity.Property(e => e.DCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("d_ciudad");

                entity.Property(e => e.DCodigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("d_codigo");

                entity.Property(e => e.DCp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("d_CP");

                entity.Property(e => e.DEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("d_estado");

                entity.Property(e => e.DMnpio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("D_mnpio");

                entity.Property(e => e.DTipoAsenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("d_tipo_asenta");

                entity.Property(e => e.DZona)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("d_zona");

                entity.Property(e => e.IdAsentaCpcons)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_asenta_cpcons");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC1E748A92D");

                entity.ToTable("Estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPedido)
                    .HasName("PK__EstadoPe__86B98371A624B117");

                entity.ToTable("EstadoPedido");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__61005978FA9A0894");

                entity.ToTable("Municipio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Municipio__IdEst__29572725");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__9D335DC325A598AF");

                entity.ToTable("Pedido");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__Pedido__IdDirecc__2645B050");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .HasConstraintName("FK__Pedido__IdEstado__2739D489");

                entity.HasOne(d => d.IdRepartidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdRepartido)
                    .HasConstraintName("FK__Pedido__IdRepart__282DF8C2");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK__Pedido__IdSucurs__245D67DE");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdTipoPago)
                    .HasConstraintName("FK__Pedido__IdTipoPa__25518C17");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pedido__IdUsuari__236943A5");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__0988921073EEED60");

                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdSubCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdSubCategoria)
                    .HasConstraintName("FK__Producto__IdSubC__76969D2E");
            });

            modelBuilder.Entity<ProductoSucursal>(entity =>
            {
                entity.HasKey(e => e.IdProductoSucursal)
                    .HasName("PK__Producto__2A0978AD41CC6073");

                entity.ToTable("ProductoSucursal");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductoSucursals)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__ProductoS__IdPro__02FC7413");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.ProductoSucursals)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK__ProductoS__IdSuc__03F0984C");
            });

            modelBuilder.Entity<Repartidor>(entity =>
            {
                entity.HasKey(e => e.IdRepartidor)
                    .HasName("PK__Repartid__BF0B3B9A8DDBB22C");

                entity.ToTable("Repartidor");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584C11388D7C");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategorium>(entity =>
            {
                entity.HasKey(e => e.IdSubCategoria)
                    .HasName("PK__SubCateg__0A1EFFE5C0E0E196");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.SubCategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__SubCatego__IdCat__73BA3083");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__Sucursal__99909FA980252DD2");

                entity.ToTable("Sucursal");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoPago)
                    .HasName("PK__TipoPago__EB0AA9E79E98F21F");

                entity.ToTable("TipoPago");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97DE506372");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UniqueEmail")
                    .IsUnique();

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdAspNet).HasMaxLength(128);

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAspNetNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdAspNet)
                    .HasConstraintName("FK__Usuario__IdAspNe__6EF57B66");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__Usuario__IdDirec__3A81B327");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuario__IdRol__1DE57479");
            });

            modelBuilder.Entity<VwusuarioGetAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VWUsuarioGetAll");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroExterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroInterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
