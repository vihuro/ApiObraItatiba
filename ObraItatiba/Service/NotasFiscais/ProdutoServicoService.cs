using AutoMapper;
using ObraItatiba.Context;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Interface.NotasTHR;
using ObraItatiba.Models.Notas;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.NotasFiscais
{
    public class ProdutoServicoService : IProdutoServicoService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public ProdutoServicoService(ContextBase context,
                                     IMapper mapper) 
        {
            this._context = context;
            _mapper = mapper;
        }

        public List<ProdutoServicoResumidoDto> Insert(InsertProdutoServicoDto dto)
        {
            if (string.IsNullOrEmpty(dto.NotaId.ToString()))
            {
                throw new ExceptionService("Campo obrigatório vazio!");
            }
            var obj = new ProdutoServicoModel()
            {
                Complemento = dto.Complemento,
                DescricaoProdutoServico = dto.DescricaoProdutoServico,
                NotaId = dto.NotaId,
            };
            _context.ProdutosServico.Add(obj);
            _context.SaveChanges();

            return BucarPorNota(obj.NotaId);
        }

        public List<ProdutoServicoResumidoDto> BucarPorNota(int id)
        {
            var obj = _context.ProdutosServico
                .Where(x => x.NotaId == id)
                .ToList();
            return _mapper.Map<List<ProdutoServicoModel>, List<ProdutoServicoResumidoDto>>(obj);
        }

    }
}
