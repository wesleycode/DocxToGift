using System;
using System.Collections.Generic;

namespace DocxToGift.model
{
    public class Questao
    {
        private string _titulo = "";
        private List<Resposta> _listaDeRespostas = new List<Resposta>();

        public string Titulo
        {
            get => _titulo;
            set => _titulo = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<Resposta> ListaDeRespostas
        {
            get => _listaDeRespostas;
            set => _listaDeRespostas = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}