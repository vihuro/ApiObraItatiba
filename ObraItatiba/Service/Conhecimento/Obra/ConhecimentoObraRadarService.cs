using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;
using ObraItatiba.Dto.Conhecimento.Obra.Notas;
using ObraItatiba.Dto.Conhecimento.Obra.Parcelas;
using ObraItatiba.Interface.Conhecimento.Obra;
using System.Text;

namespace ObraItatiba.Service.Conhecimento.Obra
{
    public class ConhecimentoObraRadarService : IConhecimentoObraService
    {
        private readonly IConhecimentoTHRService _conhecimentoObraService;
        public ConhecimentoObraRadarService(IConhecimentoTHRService _conhecimentoService)
        {
            _conhecimentoObraService = _conhecimentoService;
        }
        public List<ConhecimentoObraDto> LerArquivoTXT()
        {
            var list = new List<ConhecimentoObraDto>();
            var parcelas = new List<ParcelasConhecimentoDto>();
            using (var leitor = new StreamReader(@"C:\\api_obra\\reports\\ct_obra_bi.txt",
                                                 Encoding.GetEncoding("ISO-8859-1"), true))
            {
                leitor.ReadLine(); ;
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valor = linha.Split("|");
                    var verificao = list.Where(x => x.NumeroDocumento == Convert.ToInt32(valor[2].Replace("\"", ""))).FirstOrDefault();
                    if (verificao == null)
                    {
                        var dto = new ConhecimentoObraDto
                        {
                            DataEntrada = Convert.ToDateTime(valor[0].Replace("\"", "")),
                            DataEmissao = Convert.ToDateTime(valor[1].Replace("\"", "")),
                            NumeroDocumento = Convert.ToInt32(valor[2].Replace("\"", "")),
                            CodigoTransportadora = valor[3].Replace("\"", ""),
                            Transportadora = valor[4].Replace("\"", ""),
                            ValorFrete = decimal.Parse(valor[5].Replace("\"", "")).ToString("###,###.##"),
                        };
                        if (valor[7].Replace("\"", "") != null)
                        {
                            dto.Parcelas = new List<ParcelasConhecimentoDto>()
                            {
                                new ParcelasConhecimentoDto()
                                {
                                    Vencimento = Convert.ToDateTime(valor[8].Replace("\"","")).ToUniversalTime(),
                                    NumeroParcela = valor[7].Replace("\"",""),
                                    ValorParcela = decimal.Parse(valor[9].Replace("\"", "")).ToString("###,###.##"),
                                }
                            };
                        }
                        if (valor[11].Replace("\"", "") != null)
                        {
                            dto.Notas = new List<NotasConhecimentoDto> { new NotasConhecimentoDto()
                            {
                                NumeroNota = valor[11].Replace("\"",""),

                                Fornecedor = valor[13].Replace("\"",""),

                            } };
                            if (valor[12].Replace("\"", "") != "00/00/00" &&
                                valor[12].Replace("\"", "") != "")
                            {
                                dto.Notas[0].DataEmissao = Convert.ToDateTime(valor[12].Replace("\"", "")).ToUniversalTime();
                            }

                        }
                        list.Add(dto);

                    }
                    else
                    {
                        if (verificao.Parcelas == null)
                        {
                            var parcela = new List<ParcelasConhecimentoDto>()
                            {
                                new ParcelasConhecimentoDto()
                                {
                                    NumeroParcela = valor[7].Replace("\"",""),
                                    Vencimento = Convert.ToDateTime(valor[8].Replace("\"","")),
                                    ValorParcela = decimal.Parse(valor[9].Replace("\"", "")).ToString("###,###.##"),

                                }
                            };
                        }
                        else
                        {
                            if (valor[8].Replace("\"", "") != string.Empty)
                            {
                                verificao.Parcelas.Add(new ParcelasConhecimentoDto()
                                {
                                    NumeroParcela = valor[7].Replace("\"", ""),
                                    Vencimento = Convert.ToDateTime(valor[8].Replace("\"", "")),
                                    ValorParcela = decimal.Parse(valor[9].Replace("\"", "")).ToString("###,###.##"),
                                });
                                if (valor[12].Replace("\"", "") != "00/00/00" &&
                                    valor[12].Replace("\"", "") != "")
                                {
                                    verificao.Notas[0].DataEmissao = Convert.ToDateTime(valor[12].Replace("\"", "")).ToUniversalTime();
                                }
                            };
                        }
                        if (verificao.Notas == null)
                        {
                            var nota = new List<NotasConhecimentoDto>()
                            {
                                new NotasConhecimentoDto()
                                {
                                NumeroNota = valor[11].Replace("\"",""),
                                Fornecedor = valor[13].Replace("\"",""),
                                }
                            };
                        }
                        else
                        {
                            if (valor[11].Replace("\"", "") != string.Empty)
                            {
                                verificao.Notas.Add(new NotasConhecimentoDto
                                {
                                    NumeroNota = valor[11].Replace("\"", ""),
                                    Fornecedor = valor[13].Replace("\"", ""),
                                });
                                if (valor[12].Replace("\"","") != "00/00/00" &&
                                    valor[12].Replace("\"", "") != "")
                                {
                                    verificao.Notas[0].DataEmissao = Convert.ToDateTime(valor[12].Replace("\"", "")).ToUniversalTime();
                                }
                            }
                        }
                    }
                }
            }

            return list;
        }

        public List<ConhecimentoObraDto> GetListNotSaved()
        {
            var objRadar = LerArquivoTXT();
            var objTHR = _conhecimentoObraService.GetList();
            var obj = new List<ConhecimentoObraDto>();
            foreach(var item in objRadar)
            {
                var exists = objTHR.Any(x => x.NumeroDocumento == item.NumeroDocumento.ToString());
                if (!exists)
                {
                    obj.Add(new ConhecimentoObraDto()
                    {
                        CodigoTransportadora = item.CodigoTransportadora,
                        DataEmissao = item.DataEmissao,
                        DataEntrada = item.DataEntrada,
                        Notas = item.Notas,
                        NumeroDocumento = item.NumeroDocumento,
                        Parcelas = item.Parcelas,
                        Transportadora = item.Transportadora,
                        ValorFrete = item.ValorFrete
                    });
                }

            }
            return obj;
        }
    }
}
