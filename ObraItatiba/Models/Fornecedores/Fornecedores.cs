using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Fornecedores
{
    [Table("tab_fornecedores")]
    public class Fornecedores
    {
        [Key()]
        public int Id { get; set; }
        public string NomeFornecedor { get; set; }
        public string Cnpj { get; set; }
        [ForeignKey("tab_usuario")]
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro {get;set;}
        public DateTime DataHoraCadastro { get; set; }
    }
}
