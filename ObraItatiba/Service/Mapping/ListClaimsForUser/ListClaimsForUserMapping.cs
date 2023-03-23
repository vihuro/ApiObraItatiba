using AutoMapper;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Dto.Usuario;
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
                .ForMember(x => x.Usuarios, map => map.MapFrom(src => src.Usuarios.Select(c => new UsuarioResumidoDto
                {
                    Apelido = c.Apelido,
                    Nome = c.Nome,
                    UsuarioId = c.Id
                })))
                ;
        }
    }
}
