using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;

namespace ObraItatiba.Interface.Conhecimento.Obra
{
    public interface IConhecimentoTHRService
    {
        ConhecimentoTHRRetornoDto Insert(ConhecimentoObraTHRInsertDto dto);
        ConhecimentoTHRRetornoDto GetById(int id);
        ConhecimentoTHRRetornoDto GetByNumeroDocumento(int numeroDocumento);
        List<ConhecimentoTHRRetornoDto> GetList();
    }
}
