using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Interface.Login;
using ObraItatiba.Models.Claims;
using ObraItatiba.Service.ExceptionCuton;
using System.Linq;
using System.Security.Claims;

namespace ObraItatiba.Service.Claims
{
    public class ClaimsForUserService : IClaimsForUserService
    {
        private readonly IMapper _mapper;
        private readonly ContextBase _context;
        private readonly IClaimTypeService _claimsTypeService;


        public ClaimsForUserService(ContextBase context,
                                   IMapper mapper,
                                   IClaimTypeService claimsTypeService) 
        {

            this._context = context;
            this._mapper = mapper;
            this._claimsTypeService = claimsTypeService;
        }

        public ClaimForUserRetorno InsertClaim(ClaimsCadastroUsuarioDto dto)
        {
            if(string.IsNullOrEmpty(dto.UsuarioId.ToString()) ||
                string.IsNullOrEmpty(dto.ClaimId.ToString()))
            {
                throw new ExceptionService("Campo(s) obrigatório(s) vazio(s)!");
            }

            var claim = _claimsTypeService.SelectForId(dto.ClaimId);
            if(claim == null)
            {
                throw new ExceptionService("Regra não econtrada!");
            }

            var claimsForUser = ListClaimsForUser(dto.UsuarioId);

            var item = claimsForUser.Where(x => x.Nome == claim.Nome)
                       .FirstOrDefault();

            if(item == null)
            {
                Insert(dto);
            }
            else
            {
                Update(dto, item.ClaimId);
            }
            var obj = _context.ClaimsForUser
                .Include(u => u.Usuario)
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(c => c.Claim)
                .AsNoTracking()
                .FirstOrDefault(x => x.UsuarioId == dto.UsuarioId);

            return _mapper.Map<ClaimsForUser, ClaimForUserRetorno>(obj);
        }
        public List<ClaimsForUserDto> ListClaimsForUser(int idUsuario)
        {

            var claimForUser = _context.ClaimsForUser
                                .Include(u => u.Usuario)
                                .Include(u => u.UsuarioCadastro)
                                .Include(u => u.UsuarioAlteracao)
                                .Include(c => c.Claim)
                                .Where(x => x.UsuarioId == idUsuario)
                                .ToList();
            return _mapper.Map<List<ClaimsForUser>, List<ClaimsForUserDto>>(claimForUser);
        }

        public List<ListClaimsForUserDto> GetAllClaimsForUser()
        {
            var claims = _context.ClaimsForUser
                .Include(u => u.Usuario)
                .Include(c => c.Claim)
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .ToList();

            return _mapper.Map<List<ClaimsForUser>, List<ListClaimsForUserDto>>(claims);
        }
        private ClaimsForUserDto Insert(ClaimsCadastroUsuarioDto dto)
        {
            var obj = new ClaimsForUser()
            {
                ClaimId = dto.ClaimId,
                UsuarioId = dto.UsuarioId,
                UsuarioCadastroId = dto.UsuarioCadastroId,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioAlteracaoId = dto.UsuarioCadastroId,
                DataHoraAlteracao = DateTime.UtcNow
            };
            _context.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<ClaimsForUser, ClaimsForUserDto>(obj);
        }
        private ClaimsForUserDto Update(ClaimsCadastroUsuarioDto dto, int ClaimId)
        {
            var obj = _context.ClaimsForUser
                        .FirstOrDefault(x => x.ClaimId == ClaimId);
            obj.ClaimId = dto.ClaimId;
            obj.UsuarioAlteracaoId = dto.UsuarioCadastroId;
            obj.DataHoraAlteracao = DateTime.UtcNow;

            _context.Update(obj);
            _context.SaveChanges();
            return _mapper.Map<ClaimsForUser, ClaimsForUserDto>(obj);
        }

    }
}
