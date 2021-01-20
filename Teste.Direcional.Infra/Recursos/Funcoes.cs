using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Teste.Direcional.Infra.Recursos
{
    public class Funcoes
    {
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool ValidarEmail(String email)
        {
            bool emailValido = false;

            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
            {
                emailValido = Regex.IsMatch(email, emailRegex);
            }
            catch (RegexMatchTimeoutException)
            {
                emailValido = false;
            }

            return emailValido;
        }

        public static bool ValidarSenha(string senha)
        {
            bool senhaValida = false;

            var minLength = 4;
            var maxLength = 10;
            var numNumbers = 1;
            var carUpper = 1;
            var carSpecial = 1;

            string number = string.Format("[0-9]");
            string upper = string.Format("[A-Z]");
            string special = string.Format("[^a-zA-Z0-9]");

            int qtdNumero = 0;
            int carMaiscula = 0;
            int qtdSpecial = 0;

            try
            {
                if (Regex.IsMatch(senha, number))
                {
                    qtdNumero++;
                }
                if (Regex.IsMatch(senha, upper))
                {
                    carMaiscula++;
                }
                if (Regex.IsMatch(senha, special))
                {
                    qtdSpecial++;
                }

                // Check the length.
                if (senha.Length < minLength) { return false; }
                if (senha.Length > maxLength) { return false; }
                // Check for minimum number of occurrences.
                if (qtdNumero < numNumbers) { return false; }
                if (carMaiscula < carUpper) { return false; }
                if (qtdSpecial < carSpecial) { return false; }
            }
            catch (RegexMatchTimeoutException)
            {
                senhaValida = false;
            }          

            //Passed all checks.
            return true;

        }
    }
}
