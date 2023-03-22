using AutoMapper;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Dto.Usuario;
using ObraItatiba.Models.Usuarios;

namespace ObraItatiba.Service.Mapping.Usuario
{
    public class RetornoUsuarioMapping : Profile
    {
        public RetornoUsuarioMapping() 
        {
            CreateMap<UsuarioModel, RetornoUsuarioDto>()
                .ForMember(x => x.Claims, map => map.MapFrom(src => src.Claims.Select(c => new ClaimsForUserDto {Valor = c.Claim.Valor})))
                .ForMember(x => x.Claims, map => map.MapFrom(src => src.Claims.Select(c => new ClaimsForUserDto {Nome = c.Claim.Nome})))
                .ForMember(x => x.UsuarioId, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.NomeUsuario, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido));
        }
    }
}
