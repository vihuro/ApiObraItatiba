using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Models.Notas;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.NotasFiscais
{
    public class NotasThrService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public NotasThrService(ContextBase context,
                                IMapper mapper) 
        {  
            _context = context; 
            _mapper = mapper;
        }
        public RetornoNotaThrDto Insert(InsertNotaDto dto)
        {
            if(string.IsNullOrEmpty(dto.Cnpj) || 
                string.IsNullOrEmpty(dto.NumeroNota) ||
                string.IsNullOrEmpty(dto.Autorizador) || 
                string.IsNullOrEmpty(dto.ValorTotalNota.ToString()) ||
                string.IsNullOrEmpty(dto.DescricaoProdutoServico) || 
                string.IsNullOrEmpty(dto.Fornecedor) ||
                string.IsNullOrEmpty(dto.ProdutoServico) || 
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
            return GetNotaId(model.Id);

        }

        public RetornoNotaThrDto GetNotaNumeroNota (string numeroNota)
        {
            var obj = _context.Notas
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .FirstOrDefault(x => x.NumeroNota == numeroNota);
            return _mapper.Map<NotasModel, RetornoNotaThrDto>(obj);
        }
        public RetornoNotaThrDto GetNotaId (int id)
        {
            var obj = _context.Notas
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .FirstOrDefault (x => x.Id == id);
            return _mapper.Map<NotasModel, RetornoNotaThrDto>(obj);
        }
    }
}
