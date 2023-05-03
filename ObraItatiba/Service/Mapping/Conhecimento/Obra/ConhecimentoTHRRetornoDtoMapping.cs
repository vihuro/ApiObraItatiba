using AutoMapper;
using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;
using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;
using ObraItatiba.Models.Conhecimentos.Obra;

namespace ObraItatiba.Service.Mapping.Conhecimento.Obra
{
    public class ConhecimentoTHRRetornoDtoMapping : Profile
    {
        public ConhecimentoTHRRetornoDtoMapping()
        {
            CreateMap<ConhecimentoObraModel, ConhecimentoTHRRetornoDto>()
                .ForMember(x => x.NumeroDocumento, map => map.MapFrom(src => src.NumeroDocumento))
                .ForMember(x => x.ValorFrete, map => map.MapFrom(src => src.ValorFrete.ToString("###,###.##")))
                .ForMember(x => x.CodigoTransportador, map => map.MapFrom(src => src.CodigoTransportadora))
                .ForMember(x => x.Transportador, map => map.MapFrom(src => src.Transpotadora))
                .ForMember(x => x.Time, map => map.MapFrom(src => src.Time.Time))
                .ForPath(x => x.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForPath(x => x.UsuarioCadastro.Nome, map => map.MapFrom(src => src.UsuarioCadastro.Nome))
                .ForPath(x => x.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => src.DataHoraCadastro))
                .ForPath(x => x.UsuarioAlteracao.UsuarioId, map => map.MapFrom(src => src.UsuarioAlteracao.Id))
                .ForPath(x => x.UsuarioAlteracao.Nome, map => map.MapFrom(src => src.UsuarioAlteracao.Nome))
                .ForPath(x => x.UsuarioAlteracao.Apelido, map => map.MapFrom(src => src.UsuarioAlteracao.Apelido))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => src.DataHotaAlteracao))
                .ForMember(x => x.Notas, map => map.MapFrom(src => src.Notas.Select(n => new NotasConhecimentoDto
                {
                    DataEmissao = n.DataEmissao,
                    Fornecedor = n.Fornecedor,
                    NumeroNota = n.NumeroNota.ToString(),
                })))
                .ForMember(x => x.Parcelas, map => map.MapFrom(src => src.Parcelas.Select(p => new ParcelasConhecimentoDto
                {
                    NumeroParcela = p.NumeroParcela,
                    ValorParcela =  p.ValorParcela.ToString("###,###.##"),
                    Vencimento = p.DataVencimento
                })));
        }
    }
}
