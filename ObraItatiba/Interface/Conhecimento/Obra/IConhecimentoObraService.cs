using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;

namespace ObraItatiba.Interface.Conhecimento.Obra
{
    public interface IConhecimentoObraService
    {
        List<ConhecimentoObraDto> LerArquivoTXT();
        List<ConhecimentoObraDto> GetListNotSaved();
    }
}
