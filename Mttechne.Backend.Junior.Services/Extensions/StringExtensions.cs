using System.Text;
using System.Text.RegularExpressions;

namespace Mttechne.Backend.Junior.Services.Extensions
{
    public static class StringExtensions
    {
       public static string RemoverAcentuacao(this string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex("[^a-zA-Z0-9]");
            return regex.Replace(normalizedString, "");
        }
    }
}