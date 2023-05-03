using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Conhecimentos.Obra
{
    [Table("tab_ParcelaConhecimentoObra")]
    public class ParcelasConhecimentoObraModel
    {
        public int Id { get; set; }
        public string NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
        public int ConhecimentoObraId { get; set; }
        public virtual ConhecimentoObraModel ConhecimentoObra { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }

    }
}
