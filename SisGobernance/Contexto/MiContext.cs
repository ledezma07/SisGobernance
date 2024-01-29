using Microsoft.EntityFrameworkCore;
using SisGobernance.Models;
namespace SisGobernance.Contexto
{
    public class MiContext: DbContext    
    {
        public MiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Formulario> Formiularios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
    }
}
