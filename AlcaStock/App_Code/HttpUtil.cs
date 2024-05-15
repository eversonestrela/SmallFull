using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

/// <summary>
/// Contém funções utitilárias para http.
/// </summary>
public static class HttpUtil
{
    /// <summary>
    /// Normaliza uma url trocando o caracter ~ pelo ApplicationPath.
    /// </summary>
    /// <param name="page">Página onde a url reside.</param>
    /// <param name="url">Url a ser normalizada.</param>
    /// <returns>Url normalizada.</returns>
    public static string NormalizeUrl(Page page, string url)
    {
        string urlNormalized = url;
        if (url.StartsWith("~"))
            urlNormalized = url.Replace("~", page.Request.ApplicationPath);

        return urlNormalized;
    }

    /// <summary>
    /// Normaliza uma url trocando o caracter ~ pelo ApplicationPath da requisição atual.
    /// </summary>
    /// <param name="url">Url a ser normalizada.</param>
    /// <returns>Url normalizada.</returns>
    public static string NormalizeUrl(string url)
    {
        string urlNormalized = url;
        if (url.StartsWith("~"))
            urlNormalized = url.Replace("~", System.Web.HttpContext.Current.Request.ApplicationPath);

        return urlNormalized;
    }

    /// <summary>
    /// Retorna true caso a url esteja normalizada.
    /// </summary>
    /// <param name="url">Url a ser checada.</param>
    /// <returns>True caso a url esteja normalizada.</returns>
    public static bool IsNormalized(string url)
    {
        return !url.StartsWith("~");
    }

    /// <summary>
    /// Retorna um texto com os caracteres especiais trocados pelos caracteres HTML CODE
    /// </summary>
    /// <param name="Text">Texto que passará pela codificação</param>
    /// <returns>Texto codificado em HTML CODE</returns>
    public static string FormatCharsToHTMLEntities(string text)
    {
        System.Text.StringBuilder resultado = new System.Text.StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            resultado.Append(ChangeCharToHtmlEntity(c));
        }

        return resultado.ToString();
    }

    /// <summary>
    /// Retorna o caracter que for passado alterado para HTML CODE
    /// </summary>
    /// <param name="originalChar">Caracter que será verificado e trocado pelo HTML CODE se necessário</param>
    /// <returns>Caracter codificado em HTML CODE</returns>
    private static string ChangeCharToHtmlEntity(char originalChar)
    {
        string resultado;

        switch (originalChar)
        {
            case 'Á':
                resultado = "&Aacute;";
                break;
            case 'á':
                resultado = "&aacute;";
                break;
            case 'Ã':
                resultado = "&Atilde;";
                break;
            case 'ã':
                resultado = "&atilde;";
                break;
            case 'Â':
                resultado = "&Acirc;";
                break;
            case 'â':
                resultado = "&acirc;";
                break;
            case 'À':
                resultado = "&Agrave;";
                break;
            case 'à':
                resultado = "&agrave;";
                break;
            case 'É':
                resultado = "&Eacute;";
                break;
            case 'é':
                resultado = "&eacute;";
                break;
            case 'Ê':
                resultado = "&Ecirc;";
                break;
            case 'ê':
                resultado = "&ecirc;";
                break;
            case 'Í':
                resultado = "&Iacute;";
                break;
            case 'í':
                resultado = "&iacute;";
                break;
            case 'Õ':
                resultado = "&Otilde;";
                break;
            case 'õ':
                resultado = "&otilde;";
                break;
            case 'Ó':
                resultado = "&Oacute;";
                break;
            case 'ó':
                resultado = "&oacute;";
                break;
            case 'Ô':
                resultado = "&Ocirc;";
                break;
            case 'ô':
                resultado = "&ocirc;";
                break;
            case 'Ç':
                resultado = "&Ccedil;";
                break;
            case 'ç':
                resultado = "&ccedil;";
                break;
            case 'Ú':
                resultado = "&Uacute;";
                break;
            case 'ú':
                resultado = "&uacute;";
                break;
            case 'Ü':
                resultado = "&Uuml;";
                break;
            case 'ü':
                resultado = "&uuml;";
                break;
            case 'ª':
                resultado = "&ordf;";
                break;
            case 'º':
                resultado = "&ordm;";
                break;
            case '<':
                resultado = "&lt;";
                break;
            case '>':
                resultado = "&gt;";
                break;
            case '&':
                resultado = "&amp;";
                break;
            case '-':
                resultado = "&#45;";
                break;
            default:
                resultado = originalChar.ToString();
                break;
        }

        return resultado;
    }
}