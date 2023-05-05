using System.ComponentModel.DataAnnotations.Schema;
using ObraItatiba.Models.Fornecedores;
using ObraItatiba.Models.Usuarios;

namespace ObraItatiba.Models.Conhecimentos.Obra
{
    [Table("tab_ConhecimentosObra")]
    public class ConhecimentoObraModel
    {
        public int Id { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodigoTransportadora { get; set; }
        public string Transpotadora { get; set; }
        public decimal ValorFrete { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHotaAlteracao { get; set; }
        public string Autorizador { get; set; }
        public int TimeId { get; set; }
        public virtual TimesModel Time { get; set; }
        public virtual List<NotasConhecimentoObraModel> Notas { get; set; }
        public virtual List<ParcelasConhecimentoObraModel> Parcelas { get; set; }
    }
}
