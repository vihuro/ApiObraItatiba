using ObraItatiba.Dto.Notas;
using ObraItatiba.Migrations;
using System.Text;
using ObraItatiba.Interface.NotasRadar;

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

                    var verificao = list.Where(x => x.NumeroNota == valores[0].Replace("\"", "")).FirstOrDefault();
                    if (verificao == null)
                    {
                        var dto = new NotasArquivoTextoDto
                        {
                            NumeroNota = valores[0].Replace("\"", ""),
                            Fornecedor = valores[1].Replace("\"", ""),
                            ValorTotalNota = decimal.Parse(valores[2].Replace("\"", "")).ToString("###,###.##"),
                            Cnpj = valores[3].Replace("\"", "").Trim(),
                            DescricaoProdutoServico = valores[4].Replace("\"", ""),
                            ProdutoServico = valores[6].Replace("\"", ""),
                            NumeroDocumento = new List<NumeroDocumentoDto>()
                        {
                            new NumeroDocumentoDto()
                            {
                                NumeroDocumento = valores[5].Replace("\"", "")
                            }
                        }
                        };
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
                                    NumeroDocumento = valores[5].Replace("\"","")
                                }
                            };
                        }
                        else
                        {
                            verificao.NumeroDocumento.Add(new NumeroDocumentoDto()
                            {
                                NumeroDocumento = valores[5].Replace("\"", "")
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
