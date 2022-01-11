using System.IO;
using System.Text;

namespace DocxToGift.utils
{
    public class GerenciadorDeArquivosDeTexto
    {
        public void GravarEmArquivoDeTexto(string texto, string arquivo, Encoding encoding, bool append)
        {
            using var streamWriter = new StreamWriter(arquivo, append, encoding);
            streamWriter.Write(texto);
        }

        public string LerDeArquivoDeTexto(string arquivo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using var streamReader = new StreamReader(arquivo);
            string? line;
            while ((line = streamReader.ReadLine()) != null) 
            {
                stringBuilder.AppendLine(line);
            }
            return stringBuilder.ToString();
        }
    }
}