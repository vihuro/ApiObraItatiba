using System.Text;
using ObraItatiba.Interface.NotasRadar;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Interface.NotasTHR;

namespace ObraItatiba.Service.NotasFiscais
{
    public class NotasFiscaisTxt : INotasRadarService
    {
        public readonly INotasThrService _notasThrService;
        public NotasFiscaisTxt(INotasThrService notasThrService)
        {
            _notasThrService = notasThrService;
        }

        public List<NotasArquivoTextoDto> GerarArquivo()
        {
            var list = new List<NotasArquivoTextoDto>();
            var listNumeroDocumento = new List<Parcelas>();
            using (var leitor = new StreamReader(@"C:\\api_obra\\reports\\obra_bi_REL_teste.txt",
                                                 Encoding.GetEncoding("ISO-8859-1"), true))
            {
                leitor.ReadLine();
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split('|');

                    var verificao = list.Where(x => x.NumeroNota == valores[0] &&
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
                            Parcelas = new List<Parcelas>(),
                            ProdutoServico = new List<DescricaoProdutoServico>()
                        };
                        if (valores[9].Replace("\"", "") != string.Empty)
                        {
                            dto.Parcelas = new List<Parcelas>()
                            {
                                new Parcelas()
                                {
                                NumeroParcela = valores[5].Replace("\"", ""),
                                Vencimento = Convert.ToDateTime(valores[9].Replace("\"", "")).ToUniversalTime(),
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
                        if (verificao.Parcelas == null)
                        {

                            var documento = new List<Parcelas>()
                            {
                                new Parcelas()
                                {
                                    NumeroParcela = valores[5].Replace("\"",""),
                                    Vencimento = Convert.ToDateTime(valores[9].Replace("\"", "")).ToUniversalTime()

                                }
                            };
                        }
                        else
                        {
                            if (valores[9].Replace("\"", "") != string.Empty)
                            {

                                verificao.Parcelas.Add(new Parcelas()
                                {
                                    NumeroParcela = valores[5].Replace("\"", ""),
                                    Vencimento = Convert.ToDateTime(valores[9].Replace("\"", "")).ToUniversalTime()

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
        public List<NotasArquivoTextoDto> NotSaved()
        {
            var objTHR = _notasThrService.GetAll();
            var objRADAR = GerarArquivo();
            var obj = new List<NotasArquivoTextoDto>();
            foreach(var item in objRADAR)
            {
                var exists = objTHR.Any(x => x.NumeroNota.ToString() == item.NumeroNota &&
                                        x.Cnpj == item.Cnpj.Replace(".", "").Replace("-", "").Replace("/", ""));

                if (!exists)
                {
                    obj.Add(new NotasArquivoTextoDto
                    {
                        Cnpj = item.Cnpj,
                        Fornecedor = item.Fornecedor,
                        NumeroNota = item.NumeroNota,
                        ProdutoServico = item.ProdutoServico,
                        ValorTotalNota = item.ValorTotalNota,
                        DescricaoProdutoServico = item.DescricaoProdutoServico,
                        Parcelas = item.Parcelas
                    });
                }

            }
            
            return obj;
        }
    }
}
