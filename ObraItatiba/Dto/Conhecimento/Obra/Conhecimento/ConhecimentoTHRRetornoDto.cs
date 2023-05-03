using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;
using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Dto.Conhecimento.Obra.Conhecimento
{
    public class ConhecimentoTHRRetornoDto
    {
        public int Id { get;set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodigoTransportador { get; set; }
        public string Transportador { get; set; }
        public string ValorFrete { get; set; }
        public UsuarioResumidoDto UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public UsuarioResumidoDto UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string Time { get; set; }
        public List<ParcelasConhecimentoDto> Parcelas { get; set; }
        public List<NotasConhecimentoDto> Notas { get; set; }

    }
}
