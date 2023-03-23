using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Dto.Claims.ListClaimsForUser;
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
            var listClaimsForuser = new ListClaimsForUserModel()
            {
                ClaimsId = claim.ClaimId,
                UsuarioId = dto.UsuarioId
            };

            if (item == null)
            {
                var claimForUser = Insert(dto);
                listClaimsForuser.ClaimsId = claimForUser.Id;

                _context.ListClaimsForUser.Add(listClaimsForuser);
                _context.SaveChanges();
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
                .Include(c => c.Claim)
                .Include(u => u.Usuario)
                .Include(l => l.ListClaimsForUser)
                    .ThenInclude(u => u.Usuario)
                        .ThenInclude(c => c.Claims)
                .AsNoTracking()
                .ToList();


            var result = claims
                .GroupBy(c => c.ClaimId)
                .Select(g => new ListClaimsForUserDto
                {
                    ClaimId = g.Key,
                    Valor = g.First().Claim.Valor,
                    Nome = g.First().Claim.Nome,
                    ListUsers = g.SelectMany(c => c.ListClaimsForUser)
                    .Select(l => new ValueListClaimsForUser
                    {
                        UsuarioId = l.UsuarioId,
                        Nome = l.Usuario.Nome,
                        Apelido = l.Usuario.Apelido
                    })
                    .ToList()
                })
                .ToList();

            
            return result;
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
            _context.ClaimsForUser.Add(obj);
            _context.SaveChanges();
            obj = _context.ClaimsForUser
                .Include(c => c.Claim)
                .Include(c => c.Usuario)
                .Where(x => x.Id == obj.Id)
                .FirstOrDefault();

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
            var id = obj.ListClaimsForUser.FirstOrDefault();
            UpdateListClaimsForUser(id.Id, id.ClaimsId);
            return _mapper.Map<ClaimsForUser, ClaimsForUserDto>(obj);
        }
        private void UpdateListClaimsForUser(int id, int ClaimId)
        {
            var obj = _context.ListClaimsForUser
                .Where(x => x.Id == id)
                .FirstOrDefault();
            obj.ClaimsId = ClaimId;
            _context.Update(obj);
            _context.SaveChanges();

        }

    }
}
