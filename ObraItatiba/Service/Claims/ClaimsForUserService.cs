using AutoMapper;
using ObraItatiba.Context;
using ObraItatiba.Dto.Claims.ClaimsUser;

namespace ObraItatiba.Service.Claims
{
    public class ClaimsForUserService
    {
        private readonly IMapper _mapper;
        private readonly ContextBase _context;
        public ClaimsForUserService(ContextBase context,
                                    IMapper mapper) 
        {
            this._context = context;
            this._mapper = mapper;
        }

        public ClaimsForUserDto InsertClaim(ClaimsCadastroUsuarioDto dto)
        {
            return null;
        }
    }
}
