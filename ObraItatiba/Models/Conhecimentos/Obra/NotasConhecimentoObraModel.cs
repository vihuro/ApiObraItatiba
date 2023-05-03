using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Conhecimentos.Obra
{
    [Table("tab_NotasConhecimentoObra")]
    public class NotasConhecimentoObraModel
    {
        public int Id { get; set; }
        public int NumeroNota { get; set; }
        public string? Fornecedor { get; set; }
        public int UsuarioCadastroId { get; set; }
        public int ConhecimentoObraId { get; set; }
        public virtual ConhecimentoObraModel ConhecimentoObra { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
