namespace ObraItatiba.Dto.Notas.Thr
{
    public class InsertNotaDto
    {
        public int NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string? DescricaoProdutoServico { get; set; }
        public string? AvulsoFinalidade { get; set; }
        public string Autorizador { get; set; }
        public int UsuarioCadastroId { get; set; }
        public int TimeId { get; set; }
        public string TipoExportacao { get; set; }
        public List<InsertParcelaDto> Parcelas { get; set; }
        public List<ProdutoServicoResumidoDto> ProdutosServico { get;set; }
    }
}
