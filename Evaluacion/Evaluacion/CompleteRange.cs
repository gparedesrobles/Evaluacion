using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evaluacion
{
    public class CompleteRange
    {
        public List<int> build(List<int> numeros)
        {
            int nmax = numeros.Max();

            for (int i = nmax; i > 0; i--)
            {
                if (!numeros.Exists(n => n.Equals(i)))
                    numeros.Add(i);
            }

            return numeros.OrderBy(n=>n).ToList() ;

        }
    }
}
