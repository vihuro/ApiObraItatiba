using ObraItatiba.Dto.Notas.Radar;

namespace ObraItatiba.Interface.NotasRadar
{
    public interface INotasRadarService
    {
        List<NotasArquivoTextoDto> GerarArquivo();
        List<NotasArquivoTextoDto> NotSaved();
    }
}
