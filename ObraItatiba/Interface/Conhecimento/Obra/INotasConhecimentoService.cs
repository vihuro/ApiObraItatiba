using ObraItatiba.Dto.Conhecimento.Obra.Notas;

namespace ObraItatiba.Interface.Conhecimento.Obra
{
    public interface INotasConhecimentoService
    {
        NotasConhecimentoDto Insert(NotasConhecimentoInserDto dto);
    }
}
