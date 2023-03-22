using AutoMapper;
using ObraItatiba.Dto.Claims.ClaimsType;
using ObraItatiba.Models.Claims;

namespace ObraItatiba.Service.Mapping.ClaimType
{
    public class RetornoClaimMapping : Profile
    {
        public RetornoClaimMapping()
        {
            CreateMap<ClaimsTypeModel, RetornoClaimsTypeDto>()
                .ForPath(x => x.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                .ForPath(x => x.UsuarioCadastro.Nome, map => map.MapFrom(src => src.UsuarioCadastro.Nome))
                .ForPath(x => x.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForMember(x => x.ClaimId, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Valor, map => map.MapFrom(src => src.Valor))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => src.DataHoraCadasto));
        }
    }
}
