using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Claims
{
    [Table("tab_ClaimsForUserUsuario")]
    public class ListClaimsForUserModel
    {
        [Key()]
        public int Id { get; set; }
        [ForeignKey("tab_ClaimsForUser")]
        public int ClaimsId { get;set; }
        public virtual ClaimsForUser Claims { get; set; }
        [ForeignKey("tab_Usuario")]
        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set;}
    }
}
