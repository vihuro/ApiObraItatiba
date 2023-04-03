using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Dto.Notas.Thr
{
    public class RetornoNotaThrDto
    {
        public int Id { get; set; }
        public string NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string DescricaoServico { get; set; }
        public string AvulsoFinalidade { get;set; }
        public string Autorizador { get; set; }
        public string ProdutoServico { get; set; }
        public ParcelasResumidasDto Parcelas { get; set; }
        public UsuarioResumidoDto UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public UsuarioResumidoDto UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string Time { get; set; }

    }
}
