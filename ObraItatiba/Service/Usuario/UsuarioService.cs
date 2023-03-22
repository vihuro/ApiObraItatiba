using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Usuario;
using ObraItatiba.Models.Usuarios;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Usuario
{
    public class UsuarioService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public UsuarioService(ContextBase context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public RetornoUsuarioDto Insert(CreateUsuarioDto dto)
        {
            if (string.IsNullOrEmpty(dto.Apelido) ||
                string.IsNullOrEmpty(dto.Nome) ||
                string.IsNullOrEmpty(dto.Senha))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var usuario = ProcurarPorApelido(dto.Apelido);
            if (usuario != null)
            {
                throw new ExceptionService("Já existe um usuário com o mesmo apelido!");
            }
            var obj = new UsuarioModel()
            {
                Apelido = dto.Apelido,
                Nome = dto.Nome,
                Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
            };
            _context.Usuario.Add(obj);
            _context.SaveChanges();
            return usuario;
        }

        public RetornoUsuarioDto ProcurarPorApelido(string apelido)
        {
            if (string.IsNullOrEmpty(apelido))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var usuario = _context.Usuario
                                .Include(c => c.Claims)
                                .AsNoTracking()
                                .FirstOrDefault(x => x.Apelido == apelido);
            return _mapper.Map<UsuarioModel, RetornoUsuarioDto>(usuario);
        }
        public List<RetornoUsuarioDto> BuscarTodos()
        {
            var usuarios = _context.Usuario
                .Include(c => c.Claims)
                .AsNoTracking()
                .ToList();
            return _mapper.Map<List<UsuarioModel>, List<RetornoUsuarioDto>>(usuarios);
        }
        public RetornoUsuarioDto BuscarPorId(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }
            var usuario = _context.Usuario
                .Include(c => c.Claims)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return _mapper.Map<UsuarioModel, RetornoUsuarioDto>(usuario);
        }
    }
}
