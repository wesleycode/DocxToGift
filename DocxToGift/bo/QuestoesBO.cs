using System.Text.RegularExpressions;
using DocxToGift.model;
using DocxToGift.utils;

namespace DocxToGift.bo
{
    public class QuestoesBO
    {
        public List<Questao> ConverterListaDeLinhasEmListaDeQuestao(string texto)
        {
            // Separar texto em questoes distintas por espaço //
            string[] questoesSeparadas = GerenciadorDeStrings.SepararStringsPorLinhaEmBranco(texto);
            return questoesSeparadas.Select(questoesSeparada => ConverterTextoEmQuestao(questoesSeparada)).ToList();
        }

        private Questao ConverterTextoEmQuestao(string questaoEmTexto)
        {
            string[] texto = GerenciadorDeStrings.SepararStringsPorEnters(questaoEmTexto);
            Questao questao = new Questao();
            List<Resposta> listaDeRespostas = new List<Resposta>();
            foreach (string linha in texto)
            {
                if (isUmTituloDeQuestao(linha))
                {
                    questao.Titulo += linha;
                }
                if (isUmaAlternativaDeQuestao(linha))
                {
                    Resposta resposta = new Resposta();
                    resposta.Titulo = linha;
                    resposta.AlternativaCorreta = linha.Contains("(RESPOSTA CORRETA)");
                    listaDeRespostas.Add(resposta);
                }
            }
            questao.ListaDeRespostas = listaDeRespostas;
            return questao;
        }

        private static bool isUmTituloDeQuestao(string text)
        {
            bool value = false;
            if (Regex.IsMatch(text, @"^([0-9]{0,2}\)|[-]{1})"))
            {
                value = true;
            }

            // Ver se é um titulo de questão com outras formas de escrever, exemplo: QUESTÃO 1.{um espaço aqui, ou sem} //
            if (Regex.IsMatch(text.ToUpper(), @"^(QUEST)(Ã|A)O\s*[0-9]*(\)|.)"))
            {
                value = true;
            }
            return value;
        }

        private static bool isUmaAlternativaDeQuestao(string text)
        {
            bool value = false;
            if (Regex.IsMatch(text, @"^([a-zA-Z]{0,1}\))"))
            {
                value = true;
            }
            return value;
        }

        private Questao FormatarQuestao(Questao questao)
        {
            questao.Titulo = RemoverIdentificacaoDaQuestao(questao.Titulo);
            foreach (var resposta in questao.ListaDeRespostas)
            {
                resposta.Titulo = RemoverIdentificacaoDaQuestao(resposta.Titulo);
                resposta.Titulo = RemoverAvisoDeRespostaCorretaDaString(resposta.Titulo);
            }
            return questao;
        }

        public List<Questao> FormatarListaDeQuestoes(List<Questao> questoes)
        {
            return questoes.Select(questao => FormatarQuestao(questao)).ToList();
        }
        
        private string RemoverIdentificacaoDaQuestao(string valor)
        {
            string novoValor = Regex.Replace(valor.ToUpper(), @"^([a-zA-Z]{0,2}\)|[0-9]{0,2}\))", "");
            novoValor = Regex.Replace(novoValor, @"^([0-9]{1,2}|((QUEST)(Ã|A)O\s*))([0-9]*[\)|\.])", "");
            return novoValor;
        }

        private string RemoverAvisoDeRespostaCorretaDaString(string valor)
        {
            string newValue = valor.ToUpper();
            newValue = Regex.Replace(newValue, @"\({0,1}RESPOSTA CERTA\){0,1}", "");
            newValue = Regex.Replace(newValue, @"\({0,1}RESPOSTA CORRETA\){0,1}", "");
            newValue = Regex.Replace(newValue, @"\({0,1}QUESTÃO CERTA\){0,1}", "");
            newValue = Regex.Replace(newValue, @"\({0,1}QUESTÃO CORRETA\){0,1}", "");
            newValue = Regex.Replace(newValue, @"\({0,1}ALTERNATIVA CERTA\){0,1}", "");
            newValue = Regex.Replace(newValue, @"\({0,1}ALTERNATIVA CORRETA\){0,1}", "");
            return newValue;
        }
    }
}