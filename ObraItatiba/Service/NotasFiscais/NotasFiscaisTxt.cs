using ObraItatiba.Migrations;
using System.Text;

namespace ObraItatiba.Service.NotasFiscais
{
    public class NotasFiscaisTxt
    {
        public void GerarArquivo()
        {
            var list = new  List<TabelaNotasFiscais>();

            using (var src = new StreamReader("@\\", Encoding.GetEncoding("ISO-8859-1"), true))
            {
                var linha = "";
                var lerLinha = src.ReadLine();
                var col = lerLinha.Replace("\"", "").Split(';');
                for(int i = 0; i < col.Count(); i++)
                {

                }
            }
        }
    }
}
