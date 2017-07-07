using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evaluacion
{
    public class MoneyParts
    {

        private static List<decimal> cambio = new List<decimal>{ 0.05m, 0.1m, 0.2m, 0.5m, 1, 2, 5, 10, 20, 50, 100, 200 };

        public string[] build(string monto)
        {
            decimal conversion_monto = decimal.Parse(monto);

            List<decimal> filtro_menores = obtener_cambio_menoroigual_a_monto(conversion_monto);            
            decimal monto_total = conversion_monto;
            Parts oParts =null;
            List<Parts> combinatorios = new List<Parts>();

            foreach (decimal item in filtro_menores)
            {
                oParts = new Parts();
                oParts.lista = new List<decimal>();

                string combinacion = string.Empty;
                
                do
                {
                    if (monto_total >= item){
                        oParts.lista.Add(item);
                        monto_total -= item;
                    }
                    else
                    {
                        if (!verificar_cambio_menoroigual(monto_total))
                        {
                            break;
                        }

                        decimal cambio_menor = obtener_ultimo_cambio_menoroigual(monto_total);
                        oParts.lista.Add(cambio_menor);
                        monto_total -= cambio_menor;                        
                    }
                        

                } while (monto_total > 0);
                combinatorios.Add(oParts);
                monto_total = conversion_monto;
            }

            List<string> resultado = new List<string>();
            
            foreach (Parts item in combinatorios)
            {
                resultado.Add(string.Join(",", item.lista.ToArray()));
            }

            string[] array = resultado.ToArray();

            return array;
             
        }
        
        private bool verificar_cambio_menoroigual(decimal monto_cambio)
        {
            return obtener_cambio_menoroigual_a_monto(monto_cambio).Count>0 ? true:false;
        }        

        private decimal obtener_ultimo_cambio_menoroigual(decimal monto_cambio)
        {
            return obtener_cambio_menoroigual_a_monto(monto_cambio).Max();
        }

        private List<decimal> obtener_cambio_menoroigual_a_monto(decimal monto)
        {
            return cambio.Where(c => c <= monto).ToList();
        }



    }

    public class Parts
    {
       public List<decimal> lista { get; set; }
    }
}
