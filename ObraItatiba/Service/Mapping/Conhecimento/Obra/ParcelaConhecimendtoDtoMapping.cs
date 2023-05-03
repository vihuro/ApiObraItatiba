using AutoMapper;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;
using ObraItatiba.Models.Conhecimentos.Obra;

namespace ObraItatiba.Service.Mapping.Conhecimento.Obra
{
    public class ParcelaConhecimendtoDtoMapping : Profile
    {
        public ParcelaConhecimendtoDtoMapping() 
        {
            CreateMap<ParcelasConhecimentoObraModel, ParcelasConhecimentoDto>()
                .ForMember(x => x.NumeroParcela, map => map.MapFrom(src => src.NumeroParcela))
                .ForMember(x => x.Vencimento, map => map.MapFrom(src => src.DataVencimento));
        }
    }
}
