using AutoMapper;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Models.Notas;

namespace ObraItatiba.Service.Mapping.Notas
{
    public class NumeroDocumentoMapping : Profile
    {
        public NumeroDocumentoMapping() 
        {
            CreateMap<DocumentosModel,NumeroDocumentoDto>()
                .ForMember(x => x.NumeroDocumento, map => map.MapFrom(src => src.Documento));
        }
    }
}
