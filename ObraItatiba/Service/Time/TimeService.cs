using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Time;
using ObraItatiba.Interface.Time;
using ObraItatiba.Models.Fornecedores;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Time
{
    public class TimeService : ITimeService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public TimeService(ContextBase context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RetornoTimeDto Insert(InsertTimeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Time))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            if (BuscarPorTime(dto.Time) != null)
            {
                throw new ExceptionService("Já existe esse time!");
            }
            var obj = new TimesModel()
            {
                Time = dto.Time,
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                DataHoraAlteracao = DateTime.UtcNow
            };
            _context.Time.Add(obj);
            _context.SaveChanges();
            return BuscarPorTime(obj.Time);

        }

        public RetornoTimeDto GetForId(int id)
        {
            var obj = _context.Time
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return _mapper.Map<TimesModel,RetornoTimeDto>(obj);
        }

        public RetornoTimeDto BuscarPorTime(string time)
        {
            var obj = _context.Time
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .FirstOrDefault(x => x.Time.ToLower() == time.ToLower());
            return _mapper.Map<TimesModel, RetornoTimeDto>(obj);

        }
        public List<RetornoTimeDto> ListTimes()
        {
            var list = _context.Time
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .ToList();
            return _mapper.Map<List<TimesModel>, List<RetornoTimeDto>>(list);
        }
        public string DeleteForId(int id)
        {
            var obj = _context.Time.Find(id);
            _context.Time.Remove(obj);
            _context.SaveChanges();
            return "Item removido com sucesso!";
        }
        public string DeleteAll()
        {
            var obj = _context.Time.ToList();
            _context.RemoveRange(obj);
            _context.SaveChanges();
            return "Times exlcuidos com sucesso!";
        }

    }
}
