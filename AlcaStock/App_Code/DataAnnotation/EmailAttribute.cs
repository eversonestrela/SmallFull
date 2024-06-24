using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlcaStock.Attributes
{
    public class EmailAttribute
    {
        // Express�o regular para validar endere�os de e-mail
        private static readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Valida um �nico endere�o de e-mail
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            return Regex.IsMatch(email, emailPattern);
        }

        // Valida uma lista de endere�os de e-mail
        public static Dictionary<string, bool> ValidateEmailList(List<string> emails)
        {
            Dictionary<string, bool> emailValidity = new Dictionary<string, bool>();

            foreach (var email in emails)
            {
                emailValidity[email] = IsValidEmail(email);
            }

            return emailValidity;
        }

        // M�todo para imprimir resultados de valida��o
        public static void PrintValidationResults(Dictionary<string, bool> validationResults)
        {
            foreach (var result in validationResults)
            {
                Console.WriteLine(string.Format("{0}: {1}", result.Key, result.Value ? "V�lido" : "Inv�lido"));
            }
        }

        // Exemplo de uso da classe EmailValidator
        // Teste de e-mails individuais
        //Console.WriteLine(IsValidEmail("test@example.com")); // True
        //Console.WriteLine(IsValidEmail("invalid-email"));    // False

        //// Teste de uma lista de e-mails
        //List<string> emails = new List<string>
        //{
        //    "test1@example.com",
        //    "invalid-email",
        //    "test2@example.com",
        //    "another.invalid@com"
        //};

        //Dictionary<string, bool> results = ValidateEmailList(emails);
        //PrintValidationResults(results);
    }
}