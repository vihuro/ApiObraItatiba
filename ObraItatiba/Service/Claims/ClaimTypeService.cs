using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ObraItatiba.Context;
using ObraItatiba.Dto.Claims.ClaimsType;
using ObraItatiba.Interface.Login;
using ObraItatiba.Models.Claims;
using ObraItatiba.Service.ExceptionCuton;

namespace ObraItatiba.Service.Claims
{
    public class ClaimTypeService :  IClaimTypeService
    {
        private readonly ContextBase _context;
        private readonly IMapper _mapper;
        public ClaimTypeService(ContextBase context,
                                IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public RetornoClaimsTypeDto Insert(CreateClaimsTypeDto dto)
        {

            var claim = SelectionarPorValorNome(dto);
            if(claim != null)
            {
                throw new ExceptionService("Já existe essa regra!");
            }
            var obj = new ClaimsTypeModel()
            {
                Valor = dto.Valor.ToUpper(),
                Nome = dto.Nome.ToUpper(),
                UsuarioCadastroId = dto.UsuarioId,
                DataHoraCadasto = DateTime.UtcNow
            };
            _context.ClaimsType.Add(obj);
            _context.SaveChanges();
            var newClaim = _context.ClaimsType
                .AsNoTracking()
                .Include(u => u.UsuarioCadastro)
                .FirstOrDefault(x => x.Id == obj.Id);
            return _mapper.Map<ClaimsTypeModel, RetornoClaimsTypeDto>(newClaim);
        }

        public RetornoClaimsTypeDto SelectionarPorValorNome(CreateClaimsTypeDto dto)
        {
            var claim = _context.ClaimsType
                        .AsNoTracking()
                        .Include(u => u.UsuarioCadastro)
                        .FirstOrDefault(x => x.Nome == dto.Nome.ToUpper() &&
                                        x.Valor == dto.Valor.ToUpper());
            return _mapper.Map<ClaimsTypeModel, RetornoClaimsTypeDto>(claim);
        }
        public RetornoClaimsTypeDto SelectForId(int id)
        {
            var claim = _context.ClaimsType
                        .Include(u => u.UsuarioCadastro)
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ClaimsTypeModel, RetornoClaimsTypeDto>(claim);
        }
        
        public List<RetornoClaimsTypeDto> SelectAll()
        {
            var claim = _context.ClaimsType
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .ToList();
            return _mapper.Map<List<ClaimsTypeModel>, List<RetornoClaimsTypeDto>>(claim);
        }
    }
}
