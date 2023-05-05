using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;

namespace ObraItatiba.Dto.Conhecimento.Obra.Conhecimento
{
    public class ConhecimentoObraTHRInsertDto
    {
        public int NumeroDocumento { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodigoTransportadora { get; set; }
        public string Transportadora { get; set; }
        public decimal ValorFrete { get; set; }
        public int UsuarioCadastroId { get; set; }
        public string Autorizador { get; set; }
        public int TimeId { get; set; }
        public List<ParcelasConhecimentoDto>? Parcelas { get; set; }
        public List<NotasConhecimentoDto>? Notas { get; set; }
    }
}
