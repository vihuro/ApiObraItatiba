using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Dto.Usuario;
using ObraItatiba.Interface.Login;
using ObraItatiba.Models.Usuarios;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        private readonly IClaimsForUserService _claimsForUserService;
        private readonly ITokenService _tokenService; 
        public UsuarioService(ContextBase context,
                              IMapper mapper,
                              IClaimsForUserService claimUserService,
                              ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _claimsForUserService = claimUserService;
            _tokenService = tokenService;
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
            if(dto.Claims.Count > 0)
            {
                InsertClaims(dto, obj.Id);
            }
            return BuscarPorId(obj.Id);
        }
        private void InsertClaims(CreateUsuarioDto dto, int usuarioId)
        {
            var claim = new ClaimsCadastroUsuarioDto();
            foreach(var item in dto.Claims)
            {
                claim.ClaimId = item.ClaimId;
                claim.UsuarioId = usuarioId;
                claim.UsuarioCadastroId = item.UsuarioCadastroId;
                _claimsForUserService.InsertClaim(claim);
                
            }
        }

        public string Logar(LogarDto dto)
        {
            var usuario = _context.Usuario
                .FirstOrDefault(x => x.Apelido == dto.Apelido);
            if(usuario == null)
            {
                throw new ExceptionService("Usuário ou senha inválidos!");
            }
            var valid = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.Senha);
            if (!valid)
            {
                throw new ExceptionService("Usuário ou senha inválidos!");
            }
            
            return _tokenService.Create(_mapper.Map<UsuarioModel, RetornoUsuarioDto>(usuario));
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
                                .FirstOrDefault(x => x.Apelido.ToLower() == apelido.ToLower());
            return _mapper.Map<UsuarioModel, RetornoUsuarioDto>(usuario);
        }
        public List<RetornoUsuarioDto> BuscarTodos()
        {
            var usuarios = _context.Usuario
                .Include(c => c.Claims)
                    .ThenInclude(x => x.Claim)
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
                    .ThenInclude(x => x.Claim)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return _mapper.Map<UsuarioModel, RetornoUsuarioDto>(usuario);
        }
    }
}
