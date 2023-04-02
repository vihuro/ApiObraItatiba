using ObraItatiba.Dto.Notas;

namespace ObraItatiba.Interface.NotasRadar
{
    public interface INotasRadarService
    {
        List<NotasArquivoTextoDto> GerarArquivo();
    }
}
