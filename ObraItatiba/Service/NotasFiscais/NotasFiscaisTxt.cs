using System.Text;
using ObraItatiba.Interface.NotasRadar;
using ObraItatiba.Dto.Notas.Radar;

namespace ObraItatiba.Service.NotasFiscais
{
    public class NotasFiscaisTxt : INotasRadarService
    {
        public List<NotasArquivoTextoDto> GerarArquivo()
        {
            var list = new List<NotasArquivoTextoDto>();
            var listNumeroDocumento = new List<NumeroDocumentoDto>();
            using (var leitor = new StreamReader(@"C:\\api_obra\\reports\\obra_bi_REL_teste.txt",
                                                 Encoding.GetEncoding("ISO-8859-1"), true))
            {
                leitor.ReadLine();
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    var verificao = list.Where(x => x.NumeroNota == valores[0].Replace("\"", "") &&
                                    x.Cnpj == valores[3].Replace("\"", "").Trim()).FirstOrDefault();
                    if (verificao == null)
                    {
                        var dto = new NotasArquivoTextoDto
                        {
                            NumeroNota = valores[0].Replace("\"", ""),
                            Fornecedor = valores[1].Replace("\"", ""),
                            ValorTotalNota = decimal.Parse(valores[2].Replace("\"", "")).ToString("###,###.##"),
                            Cnpj = valores[3].Replace("\"", "").Trim(),
                            DescricaoProdutoServico = valores[4].Replace("\"", ""),
                            NumeroDocumento = new List<NumeroDocumentoDto>()
                            {

                            },
                            ProdutoServico = new List<DescricaoProdutoServico>()
                        };
                        if (valores[9].Replace("\"", "") != string.Empty)
                        {
                            dto.NumeroDocumento = new List<NumeroDocumentoDto>()
                            {
                                new NumeroDocumentoDto()
                                {
                                NumeroDocumento = valores[5].Replace("\"", ""),
                                Vencimento = Convert.ToDateTime(valores[9].Replace("\"", ""))
                                }
                            };
                        }
                        if ( valores[6].Replace("\"", "") != string.Empty)
                        {
                            dto.ProdutoServico = new List<DescricaoProdutoServico>()
                            {
                                new DescricaoProdutoServico()
                                {
                                    DescricaoProduto = valores[6].Replace("\"", ""),
                                    Complemento = valores[8].Replace("\"", "")
                                }
                            };
                        }
                        list.Add(dto);

                    }
                    else
                    {
                        if (verificao.NumeroDocumento == null)
                        {

                            var documento = new List<NumeroDocumentoDto>()
                            {
                                new NumeroDocumentoDto()
                                {
                                    NumeroDocumento = valores[5].Replace("\"",""),
                                    Vencimento = Convert.ToDateTime(valores[9].Replace("\"", ""))

                                }
                            };
                        }
                        else
                        {
                            if (valores[9].Replace("\"", "") != string.Empty)
                            {

                                verificao.NumeroDocumento.Add(new NumeroDocumentoDto()
                                {
                                    NumeroDocumento = valores[5].Replace("\"", ""),
                                    Vencimento = Convert.ToDateTime(valores[9].Replace("\"", ""))

                                });
                            }

                        }
                        if(verificao.DescricaoProdutoServico == null)
                        {
                            var descricaoServico = new List<DescricaoProdutoServico>()
                            {
                                new DescricaoProdutoServico()
                                {
                                    DescricaoProduto = valores[6].Replace("\"", ""),
                                    Complemento = valores[8].Replace("\"", "")

                                }
                            };
                        }
                        else
                        {
                            if (valores[6].Replace("\"","") != string.Empty)
                            {
                                verificao.ProdutoServico.Add(new DescricaoProdutoServico()
                                {
                                    DescricaoProduto = valores[6].Replace("\"", ""),
                                    Complemento = valores[8].Replace("\"", "")
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
