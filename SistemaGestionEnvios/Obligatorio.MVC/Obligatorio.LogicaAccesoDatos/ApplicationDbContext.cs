using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.VO.Agencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().OwnsOne(a => a.NombreCompleto, n =>
            {
                n.Property(p => p.Nombre).HasColumnName("Nombre");
                n.Property(p => p.Apellido).HasColumnName("Apellido");
            });

            modelBuilder.Entity<Agencia>().OwnsOne(a => a.Ubicacion, n =>
            {
                n.Property(p => p.Latitud).HasColumnName("Latitud");
                n.Property(p => p.Longitud).HasColumnName("Longitud");
            });

            modelBuilder.Entity<Envio>()
            .HasDiscriminator<string>("TipoDeEnvio")
            .HasValue<Comun>("Comun")
            .HasValue<Urgente>("Urgente");

            modelBuilder.Entity<Envio>()
            .Property(e => e.Peso)
            .HasPrecision(18, 4);
        }
    }
}
