namespace DocxToGift.utils
{
    public class RegexUtilitarios
    {
        public static string QUESTAO_COM_NUMERACAO = @"^[0-9]{1,2}|(QUEST)(Ã|A)O(\s*|-)[0-9]*[\)|\.|-]{0,1}";
        public static string NUMERACAO_OU_LETRA_COM_FECHA_COLCHETES = @"^([a-zA-Z]|[0-9]){1,3}\)";
        public static string APENAS_LETRAS_COM_FECHA_COLCHETES = @"^([a-zA-Z]){1,3}\)";
    }
}
