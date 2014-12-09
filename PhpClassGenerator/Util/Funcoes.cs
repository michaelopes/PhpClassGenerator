using System;
using System.Text;

namespace PhpClassGenerator.Util
{
    public static class Funcoes
    {
        public static string limparCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").Replace(" ", "");
        }

        public static string limparTelefone(string telefone)
        {
            return telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }

        public static string AdicionarEspaco(string valor, int qtdEspaco)
        {
            return valor.PadLeft(qtdEspaco);
        }

        public static string CompletarZerosDireita(string valor, int qtdEspaco)
        {
            return valor.PadRight(qtdEspaco, '0'); ;
        }

        public static string CompletarEspacoDireita(string valor, int qtdEspaco)
        {
            string vl = "";
            if (valor != null)
                vl = valor;
            return vl.PadRight(qtdEspaco, ' '); ;
        }
        public static string CompletarEspacoEsquerda(string valor, int qtdEspaco)
        {
            string vl = "";
            if (valor != null)
                vl = valor;
            return vl.PadLeft(qtdEspaco, ' '); ;
        }

        public static string CompletarZerosEsquerda(string valor, int qtdEspaco)
        {
            return valor.PadLeft(qtdEspaco, '0');
        }

        public static string RemoveCaracteresEspeciais(string texto, bool aceitaEspaco, bool substituiAcentos)
        {
            string ret = texto;

            if (string.IsNullOrEmpty(ret))
                return ret;

            if (substituiAcentos)
                ret = RemoveAcentos(ret);

            if (aceitaEspaco)
                ret = System.Text.RegularExpressions.Regex.Replace(ret, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
            else
                ret = System.Text.RegularExpressions.Regex.Replace(ret, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

            return ret;
        }

        public static string RemoveAcentos(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                sb.Append(s_Accents[text[i]]);

            return sb.ToString();
        }

        private static readonly char[] s_Accents = GetAccents();

        private static char[] GetAccents()
        {
            char[] accents = new char[256];

            for (int i = 0; i < 256; i++)
                accents[i] = (char)i;

            accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'a';
            accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';

            accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'e';
            accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';

            accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'i';
            accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';

            accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'o';
            accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';

            accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'u';
            accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';

            accents[(byte)'ç'] = 'c';
            accents[(byte)'Ç'] = 'C';

            accents[(byte)'ñ'] = 'n';
            accents[(byte)'Ñ'] = 'N';

            accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'y';
            accents[(byte)'Ý'] = 'Y';

            return accents;
        }

        //Chache handler
        public static int CacheHandler()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 9999);
            return randomNumber;
        }



        //ConverterParaMoedaReal
        /// <summary>
        /// Autor: Leandro Curioso
        /// Data: 26.11.2014
        /// Descrição: Resonsavel pelo conversão de string em moeda real
        /// </summary>
        /// <param name="valor">String com o valor</param>
        /// <returns>Retorna o valor em decimal da moeda em real</returns>
        public static decimal ConverterParaMoedaReal(string valor)
        {
            var arrValor = valor.Split(Convert.ToChar(","));
            var parsedValor = "";
            if (arrValor.Length > 1)
            {
                if (arrValor[1].Length > 2)
                {
                    valor = arrValor[0] + "," + arrValor[1].Substring(0, 2);
                }
            }
            return Convert.ToDecimal(string.Format("{0:C}", valor));
        }
    }

}
