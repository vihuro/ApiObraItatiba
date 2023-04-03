using Microsoft.EntityFrameworkCore;
using ObraItatiba.Models.Claims;
using ObraItatiba.Models.Fornecedores;
using ObraItatiba.Models.Notas;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<ClaimsTypeModel> ClaimsType { get; set; }
        public DbSet<ClaimsForUser> ClaimsForUser { get; set; }
        public DbSet<ListClaimsForUserModel> ListClaimsForUser { get; set; }
        public DbSet<NotasModel> Notas { get; set; }
        public DbSet<DocumentosModel> Documentos { get; set; }
        public DbSet<TimesModel> Time { get; set; }
    }
}
