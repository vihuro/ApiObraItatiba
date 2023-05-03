using AutoMapper;
using ObraItatiba.Context;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;
using ObraItatiba.Interface.Conhecimento.Obra;
using ObraItatiba.Models.Conhecimentos.Obra;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Conhecimento.Obra
{
    public class ParcelasConhecimentoObraService : IParcelaConhecimentoService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public ParcelasConhecimentoObraService(ContextBase context,
                                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ParcelasConhecimentoDto Insert(ParcelasConhecimentoInsertDto dto)
        {
            if(string.IsNullOrEmpty(dto.NumeroParcela) || 
                string.IsNullOrEmpty(dto.Vencimento.ToString()) ||
                string.IsNullOrEmpty(dto.UsuarioCadastroId.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = new ParcelasConhecimentoObraModel()
            {
                NumeroParcela = dto.NumeroParcela,
                ValorParcela = dto.ValorParcela,
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraCadastro = DateTime.UtcNow,
                DataVencimento = dto.Vencimento,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                ConhecimentoObraId = dto.ConhecimentoObraId
            };
            _context.ParcelasConhecimentoObra.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<ParcelasConhecimentoObraModel, ParcelasConhecimentoDto>(obj);
        } 
    }
}
