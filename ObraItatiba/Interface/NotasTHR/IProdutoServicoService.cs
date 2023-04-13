using ObraItatiba.Dto.Notas.Thr;

namespace ObraItatiba.Interface.NotasTHR
{
    public interface IProdutoServicoService
    {
        List<ProdutoServicoResumidoDto> Insert(InsertProdutoServicoDto dto);
        List<ProdutoServicoResumidoDto> BucarPorNota(int id);
    }
}
