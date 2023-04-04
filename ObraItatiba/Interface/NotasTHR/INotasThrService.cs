using ObraItatiba.Dto.Notas.Thr;

namespace ObraItatiba.Interface.NotasTHR
{
    public interface INotasThrService
    {
        RetornoNotaThrDto Insert(InsertNotaDto dto);
        RetornoNotaThrDto GetNotaNumeroNota(string numeroNota);
        RetornoNotaThrDto GetNotaId(int id);
    }
}
