namespace ObraItatiba.Dto.Notas.Thr
{
    public class InsertNotaDto
    {
        public string NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public string AvulsoFinalidade { get; set; }
        public string Autorizador { get; set; }
        public string ProdutoServico { get; set; }
        public int UsuarioCadastroId { get; set; }
        public int TimeId { get; set; }
    }
}
