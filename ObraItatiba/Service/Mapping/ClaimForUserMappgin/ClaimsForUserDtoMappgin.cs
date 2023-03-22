using AutoMapper;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Models.Claims;

namespace ObraItatiba.Service.Mapping.ClaimForUser
{
    public class ClaimsForUserDtoMappgin :  Profile
    {
        public ClaimsForUserDtoMappgin() 
        {
            CreateMap<ClaimsForUser, ClaimsForUserDto>()
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Claim.Nome))
                .ForMember(x => x.Valor, map => map.MapFrom(src => src.Claim.Valor))
                .ForMember(x => x.ClaimId, map => map.MapFrom(src => src.Claim.Id));
        }
    }
}
