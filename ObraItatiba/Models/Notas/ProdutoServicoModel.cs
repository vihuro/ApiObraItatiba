using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Notas
{
    [Table("tab_ProdutosServico")]
    public class ProdutoServicoModel
    {
        [Key()]
        public int Id { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public string Complemento { get; set; }
        public int NotaId { get; set; }
        public virtual NotasModel Nota { get; set; }

    }
}
