using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Extensions
{
    public static class Remove_Acentos
    {

        public static string RemoverAcentos(this string texto)
        {
            String textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            StringBuilder textoSemAcento = new StringBuilder();
            for (int i = 0; i < textoNormalizado.Length; i++)
            {
                Char c = textoNormalizado[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    textoSemAcento.Append(c);
            }
            return textoSemAcento.ToString();
        }
    }
}
