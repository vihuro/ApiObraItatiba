using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Notas.Documentos;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Interface.NotasTHR;
using ObraItatiba.Models.Notas;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.NotasFiscais
{
    public class NotasThrService : INotasThrService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        private readonly IparcelasService _parcelasService;
        public NotasThrService(ContextBase context,
                                IMapper mapper,
                                IparcelasService parcelaService) 
        {  
            _context = context; 
            _mapper = mapper;
            _parcelasService = parcelaService;
        }
        public RetornoNotaThrDto Insert(InsertNotaDto dto)
        {
            if(string.IsNullOrEmpty(dto.Cnpj) || 
                string.IsNullOrEmpty(dto.NumeroNota.ToString()) ||
                string.IsNullOrEmpty(dto.Autorizador) || 
                string.IsNullOrEmpty(dto.ValorTotalNota.ToString())  || 
                string.IsNullOrEmpty(dto.Fornecedor) || 
                string.IsNullOrEmpty(dto.TimeId.ToString()) ||
                string.IsNullOrEmpty(dto.UsuarioCadastroId.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            if (GetNotaNumeroNota(dto.NumeroNota) != null) throw new ExceptionService("Já existe essa nota!");

            var model = new NotasModel()
            {
                ProdutoServico = dto.ProdutoServico,
                NumeroNota = dto.NumeroNota,
                Autorizador = dto.Autorizador,
                AvulsoFinalidade = dto.AvulsoFinalidade,
                Cnpj = dto.Cnpj,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraAlteracao = DateTime.UtcNow,
                DescricaoProdutoServico = dto.DescricaoProdutoServico,
                Fornecedor = dto.Fornecedor,
                TimeId = dto.TimeId,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                ValorTotalNota = dto.ValorTotalNota
            };
            _context.Notas.Add(model);
            _context.SaveChanges();
            if(dto.Parcelas.Count > 0)
            {
                foreach(var item in dto.Parcelas)
                {
                    var parcela = new InserirDocumentosDto()
                    {
                        NumeroDocumento = item.Parcela,
                        NumeroNotaId = model.Id,
                        UsuarioCadastroId = model.UsuarioCadastroId
                    };
                    _parcelasService.Insert(parcela);
                }
            }
            return GetNotaId(model.Id);

        }

        public RetornoNotaThrDto GetNotaNumeroNota(int numeroNota)
        {
            var obj = _context.Notas
                .Include(n => n.Documentos)
                .FirstOrDefault(n => n.NumeroNota == numeroNota);
            return _mapper.Map<NotasModel, RetornoNotaThrDto>(obj);
        }
        public RetornoNotaThrDto GetNotaId (int id)
        {
            var obj = _context.Notas
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefault (x => x.Id == id);
            return _mapper.Map<NotasModel, RetornoNotaThrDto>(obj);
        }

        public List<RetornoNotaThrDto> GetAll()
        {
            var obj = _context.Notas
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(d => d.Documentos)
                .Include(x => x.Time)
                .ToList();
            return _mapper.Map<List<NotasModel>, List<RetornoNotaThrDto>>(obj);
        }

        public string DeleteAll()
        {
            var obj = _context.Notas
                .ToList();
            _context.RemoveRange(obj);
            _context.SaveChanges();
            return "Notas exluidas com sucesso!";
        }
    }
}
