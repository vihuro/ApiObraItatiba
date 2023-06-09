﻿using AutoMapper;
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
                .ForMember(x => x.ProdutosServico, map => map.MapFrom(src => src.ProdutosServico.Select(p => new ProdutoServicoResumidoDto
                {
                    Complemento = p.Complemento,
                    DescricaoProdutoServico = p.DescricaoProdutoServico
                })))
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
                .ForMember(x => x.TipoExportacao, map => map.MapFrom(src => src.TipoExportacao))
                .ForPath(x => x.Time, map => map.MapFrom(src => src.Time.Time))
                .ForMember(x => x.Parcelas, map => map.MapFrom(src => src.Parcelas.Select(d => new ParcelasResumidasDto { 
                    Parcela = d.NumeroParcela,
                    StatusParcela = d.Status,
                    Vencimento = d.Vencimento
                
                })))
                ;
        }
    }
}
