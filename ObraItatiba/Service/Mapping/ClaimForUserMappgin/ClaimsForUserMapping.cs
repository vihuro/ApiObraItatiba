using AutoMapper;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Models.Claims;

namespace ObraItatiba.Service.Mapping.ClaimForUser
{
    public class ClaimsForUserMapping :  Profile
    {
        public ClaimsForUserMapping() 
        {
            CreateMap<ClaimsForUser, ClaimForUserRetorno>()
                .ForMember(x => x.ClaimsId, map => map.MapFrom(src => src.Claim.Id))
                .ForMember(x => x.Valor, map => map.MapFrom(src => src.Claim.Valor))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Claim.Nome))
                .ForPath(x => x.Usuario.UsuarioId, map => map.MapFrom(src => src.Usuario.Id))
                .ForPath(x => x.Usuario.Apelido, map => map.MapFrom(src => src.Usuario.Apelido))
                .ForPath(x => x.Usuario.Nome, map => map.MapFrom(src => src.Usuario.Nome))
                .ForPath(x => x.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForPath(x => x.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                .ForPath(x => x.UsuarioCadastro.Nome, map => map.MapFrom(src => src.UsuarioCadastro.Nome))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => src.DataHoraCadastro))
                .ForPath(x => x.UsuarioAlteracao.UsuarioId, map => map.MapFrom(src => src.UsuarioAlteracao.Id))
                .ForPath(x => x.UsuarioAlteracao.Apelido, map => map.MapFrom(src => src.UsuarioAlteracao.Apelido))
                .ForPath(x => x.UsuarioAlteracao.Nome, map => map.MapFrom(src => src.UsuarioAlteracao.Nome))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => src.DataHoraAlteracao));
        }
    }
}
