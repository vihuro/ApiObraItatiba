using ObraItatiba.Models.Usuarios;

namespace ObraItatiba.Dto.Notas.Radar
{
    public class NotasArquivoTextoDto
    {
        public string NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public string ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public List<NumeroDocumentoDto> NumeroDocumento { get; set; }
        public string ProdutoServico { get; set; }

    }
}
