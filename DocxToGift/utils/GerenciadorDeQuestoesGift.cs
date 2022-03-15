using System.Collections.Generic;
using System.Text;
using DocxToGift.model;

namespace DocxToGift.utils
{
    public class GerenciadorDeQuestoesGift
    {
        public string ConverterListaDeQuestoesFormatoGIFT(List<Questao> questoes, string prefixo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (var x = 0 ; x < questoes.Count ; x++)
            {
                stringBuilder.Append(ConverterParaGIFT(questoes[x], x, prefixo));
                stringBuilder.Append("\n\n");
            }
            return stringBuilder.ToString();
        }
        
        private string ConverterParaGIFT(Questao questao, long idQuestao, string prefixoDaQuestao)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("::");
            stringBuilder.Append(prefixoDaQuestao == "" ? "DT0-A0-" : prefixoDaQuestao);
            stringBuilder.Append("Questão");
            stringBuilder.Append(idQuestao);
            stringBuilder.Append("::[html]");
            stringBuilder.Append(questao.Titulo);
            stringBuilder.Append("{");
            foreach (var resposta in questao.ListaDeRespostas)
            {
                stringBuilder.Append(resposta.AlternativaCorreta ? "=" : "~");
                stringBuilder.Append(resposta.Titulo);
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}