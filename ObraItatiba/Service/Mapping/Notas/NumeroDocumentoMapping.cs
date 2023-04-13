using AutoMapper;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Models.Notas;

namespace ObraItatiba.Service.Mapping.Notas
{
    public class NumeroDocumentoMapping : Profile
    {
        public NumeroDocumentoMapping() 
        {
            CreateMap<ParcelasModel,ParcelasResumidasDto>()
                .ForMember(x => x.Parcela, map => map.MapFrom(src => src.NumeroParcela))
                .ForMember(x => x.Vencimento, map => map.MapFrom(src => src.Vencimento))
                .ForMember(x => x.StatusParcela, map => map.MapFrom(src => src.Status));
        }
    }
}
