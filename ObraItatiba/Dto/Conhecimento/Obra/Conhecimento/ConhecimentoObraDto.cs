using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;

namespace ObraItatiba.Dto.Conhecimento.Obra.Conhecimento
{
    public class ConhecimentoObraDto
    {
        public int NumeroDocumento { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Transportadora { get; set; }
        public string CodigoTransportadora { get; set; }
        public string ValorFrete { get; set; }
        public List<ParcelasConhecimentoDto> Parcelas { get; set; }
        public List<NotasConhecimentoDto> Notas { get; set; }
    }
}
