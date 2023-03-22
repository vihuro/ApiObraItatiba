using ObraItatiba.Models.Claims;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Usuarios
{
    [Table("tab_Usuario")]
    public class UsuarioModel
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
        public virtual List<ClaimsForUser> Claims { get; set; }
    }
}
