using System;

namespace DocxToGift.model
{
    public class Resposta
    {
        private string _titulo = "";
        private bool _alternativaCorreta;

        public string Titulo
        {
            get => _titulo;
            set => _titulo = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool AlternativaCorreta
        {
            get => _alternativaCorreta;
            set => _alternativaCorreta = value;
        }
    }
}