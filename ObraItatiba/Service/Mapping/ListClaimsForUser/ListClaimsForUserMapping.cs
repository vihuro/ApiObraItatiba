using AutoMapper;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Dto.Claims.ListClaimsForUser;
using ObraItatiba.Models.Claims;

namespace ObraItatiba.Service.Mapping.ListClaimsForUser
{
    public class ListClaimsForUserMapping : Profile
    {
        public ListClaimsForUserMapping()
        {
            CreateMap<ClaimsForUser, ListClaimsForUserDto>()
                .ForMember(x => x.Valor, map => map.MapFrom(src => src.Claim.Valor))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Claim.Nome))
                .ForPath(x => x.ListUsers, map => map.Ignore())
                .AfterMap((src, dest) =>
                {
                    var group = src.ListClaimsForUser
                    .GroupBy(x => x.ClaimsId)
                    .ToDictionary(x => x.Key, c => c.Select(u => new ValueListClaimsForUser
                    {
                        Apelido = u.Usuario.Apelido,
                        Nome = u.Usuario.Nome,
                        UsuarioId = u.Usuario.Id
                    }).ToList());
                    dest.ListUsers = group.GetValueOrDefault(src.ClaimId, new List<ValueListClaimsForUser>());
                });
        }
    }
}
