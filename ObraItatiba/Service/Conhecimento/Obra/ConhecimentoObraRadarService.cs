using ObraItatiba.Dto.Conhecimento.Obra;
using ObraItatiba.Interface.Conhecimento.Obra;
using System.Text;

namespace ObraItatiba.Service.Conhecimento.Obra
{
    public class ConhecimentoObraRadarService : IConhecimentoObraService
    {
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
                            ValorFrete = valor[5].Replace("\"", "")
                        };
                        if (valor[7].Replace("\"", "") != null)
                        {
                            dto.Parcelas = new List<ParcelasConhecimentoDto>()
                            {
                                new ParcelasConhecimentoDto()
                                {
                                    Vencimento = Convert.ToDateTime(valor[8].Replace("\"","")).ToUniversalTime(),
                                    NumeroParcela = valor[7].Replace("\"","")
                                }
                            };
                        }
                        if (valor[11].Replace("\"", "") != null)
                        {
                            dto.Notas = new List<NotasConhecimentoDto> { new NotasConhecimentoDto()
                            {
                                NumeroNota = valor[11].Replace("\"",""),
                                DataEmissao = valor[12].Replace("\"",""),
                                Fornecedor = valor[13].Replace("\"","")

                            } };

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
                                    Vencimento = Convert.ToDateTime(valor[8].Replace("\"",""))
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
                                    Vencimento = Convert.ToDateTime(valor[8].Replace("\"", ""))
                                });
                            };
                        }
                        if (verificao.Notas == null)
                        {
                            var nota = new List<NotasConhecimentoDto>()
                            {
                                new NotasConhecimentoDto()
                                {
                                NumeroNota = valor[11].Replace("\"",""),
                                DataEmissao = valor[12].Replace("\"",""),
                                Fornecedor = valor[13].Replace("\"","")
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
                                    DataEmissao = valor[12].Replace("\"", ""),
                                    Fornecedor = valor[13].Replace("\"", "")
                                });
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}
