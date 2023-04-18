using ObraItatiba.Dto.Time;

namespace ObraItatiba.Interface.Time
{
    public interface ITimeService
    {
        RetornoTimeDto Insert(InsertTimeDto dto);
        RetornoTimeDto BuscarPorTime(string time);
        List<RetornoTimeDto> ListTimes();
        RetornoTimeDto GetForId(int id);
        string DeleteForId(int id);
        string DeleteAll();
    }
}
