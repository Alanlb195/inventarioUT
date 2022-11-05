using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class InventarioUTDBContext : DbContext
    {
        public InventarioUTDBContext()
        {
        }

        public InventarioUTDBContext(DbContextOptions<InventarioUTDBContext> options)
            : base(options)
        {
        }

        public DbSet<Edificio> Edificios { get; set; }
        public DbSet<Taller> Talleres { get; set; }

        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<DetalleOrden> DetalleOrdenes { get; set; }

        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Plazo> Plazos { get; set; }
        public DbSet<Multa> Multas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }

        public DbSet<Estatus> Estatus { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Edificio>().ToTable("Edificio");
            modelBuilder.Entity<Taller>().ToTable("Taller");

            modelBuilder.Entity<Herramienta>().ToTable("Herramienta");
            modelBuilder.Entity<Marca>().ToTable("Marca");

            modelBuilder.Entity<DetalleOrden>().ToTable("DetalleOrden");

            modelBuilder.Entity<Orden>().ToTable("Orden");
            modelBuilder.Entity<Plazo>().ToTable("Plazo");
            modelBuilder.Entity<Multa>().ToTable("Multa");

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<RolUsuario>().ToTable("RolUsuario");
        }

    }
}