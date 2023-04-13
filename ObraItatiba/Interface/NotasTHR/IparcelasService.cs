using ObraItatiba.Dto.Notas.Documentos;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Dto.Notas.Thr;

namespace ObraItatiba.Interface.NotasTHR
{
    public interface IparcelasService
    {
        List<ParcelasResumidasDto> Insert(InserirDocumentosDto dto);
        List<ParcelasResumidasDto> GetListDocumentosNotaId(int notaId);

    }
}
