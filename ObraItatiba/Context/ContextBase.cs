using Microsoft.EntityFrameworkCore;
using ObraItatiba.Models.Claims;
using ObraItatiba.Models.Fornecedores;
using ObraItatiba.Models.Usuarios;

namespace ObraItatiba.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) :  base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                        .HasMany(u => u.Claims)
                        .WithOne(c => c.Usuario)
                        .HasForeignKey(c => c.UsuarioId);
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<ClaimsTypeModel> ClaimsType { get; set; }
        public DbSet<ClaimsForUser> ClaimsForUser { get; set; }
    }
}
