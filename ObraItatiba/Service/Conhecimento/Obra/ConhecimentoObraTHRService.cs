using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;
using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;
using ObraItatiba.Interface.Conhecimento.Obra;
using ObraItatiba.Models.Conhecimentos.Obra;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Conhecimento.Obra
{
    public class ConhecimentoObraTHRService : IConhecimentoTHRService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        private readonly IParcelaConhecimentoService _parcelaService;
        private readonly INotasConhecimentoService _notasService;
        public ConhecimentoObraTHRService(ContextBase context,
                                          IMapper mapper,
                                          IParcelaConhecimentoService parcelaService,
                                          INotasConhecimentoService notasService)
        {
            _context = context;
            _mapper = mapper;
            _parcelaService = parcelaService;
            _notasService = notasService;
        }
        public ConhecimentoTHRRetornoDto Insert(ConhecimentoObraTHRInsertDto dto)
        {
            if (string.IsNullOrEmpty(dto.CodigoTransportadora) ||
                string.IsNullOrEmpty(dto.NumeroDocumento.ToString()) ||
                string.IsNullOrEmpty(dto.DataEmissao.ToString()) ||
                string.IsNullOrEmpty(dto.ValorFrete.ToString()) ||
                string.IsNullOrEmpty(dto.DataEntrada.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            if (GetByNumeroDocumento(dto.NumeroDocumento) != null)
            {
                throw new ExceptionService("Conhecimento já cadastrado!");
            }
            var obj = new ConhecimentoObraModel()
            {
                NumeroDocumento = dto.NumeroDocumento,
                Transpotadora = dto.Transportadora,
                CodigoTransportadora = dto.CodigoTransportadora,
                DataEmissao = dto.DataEmissao.ToUniversalTime(),
                DataEntrada = dto.DataEntrada.ToUniversalTime(),
                ValorFrete = dto.ValorFrete,
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                DataHotaAlteracao = DateTime.UtcNow,
                TimeId = dto.TimeId,
                Autorizador = dto.Autorizador,

            };
            _context.ConhecimentosObra.Add(obj);
            _context.SaveChanges();
            if (dto.Parcelas.Count > 0)
            {
                var parcela = new ParcelasConhecimentoInsertDto();
                foreach (var item in dto.Parcelas)
                {
                    parcela.NumeroParcela = item.NumeroParcela;
                    parcela.UsuarioCadastroId = dto.UsuarioCadastroId;
                    parcela.NumeroParcela = item.NumeroParcela;
                    parcela.Vencimento = Convert.ToDateTime(item.Vencimento).ToUniversalTime();
                    parcela.ConhecimentoObraId = obj.Id;
                    parcela.ValorParcela = decimal.Parse(item.ValorParcela);
                    _parcelaService.Insert(parcela);
                }
            }
            if (dto.Notas.Count > 0)
            {
                var nota = new NotasConhecimentoInserDto();
                foreach (var item in dto.Notas)
                {
                    nota.DataEmissao = Convert.ToDateTime(item.DataEmissao).ToUniversalTime();
                    nota.UsuarioCadastroId = dto.UsuarioCadastroId;
                    nota.NumeroNota = item.NumeroNota;
                    nota.Fornecedor = item.Fornecedor;
                    nota.ConhecimentoId = obj.Id;
                    _notasService.Insert(nota);
                }

            }
            return GetById(obj.Id);
        }
        public ConhecimentoTHRRetornoDto GetById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = _context.ConhecimentosObra
                .Include(x => x.Notas)
                .Include(x => x.Parcelas)
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(t => t.Time)
                .Where(x => x.Id == id).First();
            return _mapper.Map<ConhecimentoObraModel, ConhecimentoTHRRetornoDto>(obj);
        }
        public ConhecimentoTHRRetornoDto GetByNumeroDocumento(int numeroDocumento)
        {
            if (string.IsNullOrEmpty(numeroDocumento.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = _context.ConhecimentosObra
                .Include(x => x.Notas)
                .Include(x => x.Parcelas)
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(t => t.Time)
                .Where(x => x.NumeroDocumento == numeroDocumento).FirstOrDefault();
            return _mapper.Map<ConhecimentoObraModel, ConhecimentoTHRRetornoDto>(obj);
        }
        public List<ConhecimentoTHRRetornoDto> GetList()
        {
            var obj = _context.ConhecimentosObra
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(n => n.Notas)
                .Include(p => p.Parcelas)
                .Include(t => t.Time)
                .ToList();
            return _mapper.Map<List<ConhecimentoObraModel>, List<ConhecimentoTHRRetornoDto>>(obj);
        }
    }
}
