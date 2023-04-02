using AutoMapper;
using ObraItatiba.Dto.Time;
using ObraItatiba.Models.Fornecedores;

namespace ObraItatiba.Service.Mapping.Times
{
    public class RetornoTimeMapping : Profile
    {
        public RetornoTimeMapping() 
        {
            CreateMap<TimesModel, RetornoTimeDto>()
                .ForMember(x => x.Time, map => map.MapFrom(src => src.Time))
                .ForMember(x => x.TimeId, map => map.MapFrom(src => src.Id))
                .ForPath(u => u.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForPath(u => u.UsuarioCadastro.Nome, map => map.MapFrom(src => src.UsuarioCadastro.Nome))
                .ForPath(u => u.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                .ForPath(u => u.UsuarioAlteracao.UsuarioId, map => map.MapFrom(src => src.UsuarioAlteracao.Id))
                .ForPath(u => u.UsuarioAlteracao.Nome, map => map.MapFrom(src => src.UsuarioAlteracao.Nome))
                .ForPath(u => u.UsuarioAlteracao.Apelido, map => map.MapFrom(src => src.UsuarioAlteracao.Apelido));
        }
    }
}
