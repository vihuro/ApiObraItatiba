using AutoMapper;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Models.Notas;

namespace ObraItatiba.Service.Mapping.Notas
{
    public class ProdutoResumidoMapping : Profile
    {
        public ProdutoResumidoMapping() 
        {
            CreateMap<ProdutoServicoModel, ProdutoServicoResumidoDto>()
                .ForMember(x => x.DescricaoProdutoServico, map => map.MapFrom(src => src.DescricaoProdutoServico))
                .ForMember(x => x.Complemento, map => map.MapFrom(src => src.Complemento));
        }
    }
}
