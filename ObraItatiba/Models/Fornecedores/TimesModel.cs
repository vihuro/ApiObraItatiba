using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Fornecedores
{
    [Table("tab_time")]
    public class TimesModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
