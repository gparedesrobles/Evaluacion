using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evaluacion
{
    public class ChangeString
    {
        private static readonly List<char> abecedario = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public string build(string texto)
        {
            string resultado = string.Empty;
            char caracter;
            bool esMayuscula;
            int index = 0;

            foreach (char elemento in texto)
            {
                if (Char.IsLetter(elemento))
                {
                    esMayuscula = char.IsUpper(elemento);
                    index = abecedario.IndexOf(char.ToLower(elemento));
                    caracter = abecedario[index != abecedario.Count - 1 ? index + 1 : abecedario.Count - 1 - index]; // Si es el último caracter , continua en la primera posición
                    resultado += esMayuscula ? char.ToUpper(caracter) : caracter;
                    continue;
                }
                resultado += elemento;
            }

            return resultado;
        }
    }
}
