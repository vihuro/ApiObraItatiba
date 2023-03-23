using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Claims
{
    [Table("tab_ClaimsForUser")]
    public class ClaimsForUser
    {
        [Key()]
        public int Id { get; set; }
        [ForeignKey("tab_claimsType")]
        public int ClaimId { get; set; }
        public virtual ClaimsTypeModel Claim { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        public virtual List<ListClaimsForUserModel> ListClaimsForUser { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

    }
}
