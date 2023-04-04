using ObraItatiba.Dto.Notas.Documentos;
using ObraItatiba.Dto.Notas.Radar;

namespace ObraItatiba.Interface.NotasTHR
{
    public interface IparcelasService
    {
        List<NumeroDocumentoDto> Insert(InserirDocumentosDto dto);
        List<NumeroDocumentoDto> GetListDocumentosNotaId(int notaId);

    }
}
