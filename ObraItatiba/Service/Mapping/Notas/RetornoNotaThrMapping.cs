using AutoMapper;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Models.Notas;

namespace ObraItatiba.Service.Mapping.Notas
{
    public class RetornoNotaThrMapping : Profile
    {
        public RetornoNotaThrMapping() 
        {
            CreateMap<NotasModel, RetornoNotaThrDto>()
                .ForMember(x => x.NumeroNota, map => map.MapFrom(src => src.NumeroNota))
                .ForMember(x => x.AvulsoFinalidade, map => map.MapFrom(src => src.AvulsoFinalidade))
                .ForMember(x => x.ProdutoServico, map => map.MapFrom(src => src.ProdutoServico))
                .ForMember(x => x.DescricaoServico, map => map.MapFrom(src => src.DescricaoProdutoServico))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => src.DataHoraCadastro))
                .ForPath(x => x.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForPath(x => x.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                .ForPath(x => x.UsuarioCadastro.Nome, map => map.MapFrom(src => src.UsuarioCadastro.Nome))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => src.DataHoraAlteracao))
                .ForPath(x => x.UsuarioAlteracao.UsuarioId, map => map.MapFrom(src => src.UsuarioAlteracao.Id))
                .ForPath(x => x.UsuarioAlteracao.Apelido, map => map.MapFrom(src => src.UsuarioAlteracao.Apelido))
                .ForPath(x => x.UsuarioAlteracao.Nome, map => map.MapFrom(src => src.UsuarioAlteracao.Nome))
                .ForMember(x => x.ValorTotalNota, map => map.MapFrom(src => src.ValorTotalNota))
                .ForPath(x => x.Time, map => map.MapFrom(src => src.Time.Time))
                ;
        }
    }
}
