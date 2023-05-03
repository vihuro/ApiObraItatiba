using AutoMapper;
using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Models.Conhecimentos.Obra;

namespace ObraItatiba.Service.Mapping.Conhecimento.Obra
{
    public class NotasConhecimentoDtoMapping : Profile
    {
        public NotasConhecimentoDtoMapping() 
        {
            CreateMap<NotasConhecimentoObraModel, NotasConhecimentoDto>()
                .ForMember(x => x.DataEmissao, map => map.MapFrom(src => src.DataEmissao))
                .ForMember(x => x.NumeroNota, map => map.MapFrom(src => src.NumeroNota))
                .ForMember(x => x.Fornecedor, map => map.MapFrom(src => src.Fornecedor));
        }
    }
}
