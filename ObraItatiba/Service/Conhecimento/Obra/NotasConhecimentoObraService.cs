using AutoMapper;
using ObraItatiba.Context;
using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Interface.Conhecimento.Obra;
using ObraItatiba.Models.Conhecimentos.Obra;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Conhecimento.Obra
{
    public class NotasConhecimentoObraService : INotasConhecimentoService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public NotasConhecimentoObraService(ContextBase context,
                                            IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public NotasConhecimentoDto Insert(NotasConhecimentoInserDto dto)
        {
            if(string.IsNullOrEmpty(dto.NumeroNota) || 
                string.IsNullOrEmpty(dto.ConhecimentoId.ToString()) ||
                string.IsNullOrEmpty(dto.DataEmissao.ToString()) ||
                string.IsNullOrEmpty(dto.UsuarioCadastroId.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = new NotasConhecimentoObraModel()
            {
                ConhecimentoObraId = dto.ConhecimentoId,
                Fornecedor = dto.Fornecedor,
                NumeroNota = Convert.ToInt32(dto.NumeroNota),
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                DataHoraAlteracao = DateTime.UtcNow,
            };
            _context.NotasConhecimentoObra.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<NotasConhecimentoObraModel,NotasConhecimentoDto>(obj);
        }
    }
}
