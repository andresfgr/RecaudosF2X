using Microsoft.EntityFrameworkCore;
using VehiculosF2X.Dominio.Entidades;

namespace VehiculosF2X.Infraestrcutura
{
    public partial class DbContextRecaudoVehiculo : DbContext
    {
        public DbContextRecaudoVehiculo()
        {
        }

        public DbContextRecaudoVehiculo(DbContextOptions<DbContextRecaudoVehiculo> optiopns) : base(optiopns)
        {
        }

        public virtual DbSet<Recaudos> Recaudos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=104.46.196.254;Database=Gonzalez;Trusted_Connection=False;User=agonzalez;password=AP7ce2$_{\\DtNr,a");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recaudos>(entity => { entity.ToTable("Recaudos"); });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
