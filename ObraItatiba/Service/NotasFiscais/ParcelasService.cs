using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Notas.Documentos;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Interface.NotasTHR;
using ObraItatiba.Models.Notas;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.NotasFiscais
{
    public class ParcelasService : IparcelasService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public ParcelasService(ContextBase context,
                                IMapper mapper) 
        { 
            _context = context; 
            _mapper = mapper;
        }

        public List<NumeroDocumentoDto> Insert(InserirDocumentosDto dto)
        {
            if(string.IsNullOrEmpty(dto.NumeroDocumento) || 
                string.IsNullOrEmpty(dto.NumeroNotaId.ToString()) ||
                string.IsNullOrEmpty(dto.UsuarioCadastroId.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = new DocumentosModel()
            {
                NotaId = dto.NumeroNotaId,
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                Documento = dto.NumeroDocumento,
                DataHoraAlteracao = DateTime.UtcNow,
                Status = "Aguardado pagamento"
            };
            _context.Documentos.Add(obj);
            _context.SaveChanges();
            return GetListDocumentosNotaId(obj.NotaId);
        }
        public List<NumeroDocumentoDto> GetListDocumentosNotaId(int notaId)
        {
            var obj = _context.Documentos
                .AsNoTracking()
                .Where(x => x.NotaId == notaId)
                .ToList();
            return _mapper.Map<List<NumeroDocumentoDto>>(obj);
        }
    }
}
