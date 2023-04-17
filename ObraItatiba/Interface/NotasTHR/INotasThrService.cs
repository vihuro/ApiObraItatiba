using ObraItatiba.Dto.Notas.Thr;

namespace ObraItatiba.Interface.NotasTHR
{
    public interface INotasThrService
    {
        RetornoNotaThrDto Insert(InsertNotaDto dto);
        List<RetornoNotaThrDto> GetNotaNumeroNota(int numeroNota);
        RetornoNotaThrDto GetNotaId(int id);
        List<RetornoNotaThrDto> GetAll();
        string DeleteAll();
    }
}
