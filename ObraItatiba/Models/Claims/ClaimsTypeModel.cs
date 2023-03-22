using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Claims
{
    [Table("tab_claimsType")]
    public class ClaimsTypeModel
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        [ForeignKey("tab_Usuario")]
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadasto { get; set; }
    }
}
