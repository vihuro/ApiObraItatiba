using ObraItatiba.Models.Fornecedores;
using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Notas
{
    [Table("tab_notasFicais")]
    public class NotasModel
    {
        [Key()]
        public int Id { get; set; }
        public int NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public string? AvulsoFinalidade { get; set; }
        public string Autorizador { get; set; }
        public string ProdutoServico { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public int TimeId { get; set; }
        public virtual TimesModel Time { get; set; }
        public virtual List<DocumentosModel> Documentos { get; set; }
        
    }
}
