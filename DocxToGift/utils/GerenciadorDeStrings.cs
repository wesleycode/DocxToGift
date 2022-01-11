using System;

namespace DocxToGift.utils
{
    public class GerenciadorDeStrings
    {
        public static string[] SepararStringsPorLinhaEmBranco(string value)
        {
            return value.Split(new string[] {Environment.NewLine + Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] SepararStringsPorEnters(string value)
        {
            return value.Split(new string[] { Environment.NewLine },
                StringSplitOptions.None);
        }
    }
}