using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAGMinim
{
    /*
    Universidad Autonoma Del Estado de Mexico
    C.U. UAEM Zumpango 
    Ingenieria en Computacion
    Algoritmos Geneticos
    Juan Carlos Angeles Vazquez
    27/Marzo/2018
    Encuentra el mínimo de la función f(x)=cos(x)*e^{-pi*x/100} en el intervalo de x [-10 a 10]

    Usa la representación real con codificación Gray.
*/
    public class Gen
    {
        public int[] gene;
        public int BITS_PER_GENE; //Bits del gen
        private double min, max;
        private int partic;

        public Gen(double min, double max, int partic)
        {
            this.partic = partic;
            this.min = min;
            this.max = max;
            BITS_PER_GENE = (int)(Math.Log10(partic) / Math.Log10(2));
            gene = new int[BITS_PER_GENE];
            // Console.WriteLine("Tam gen: " + gene.Length);
        }
        public void inicializa(Random ran)
        {

            for (int i = 0; i < BITS_PER_GENE; i++)
            {
                if (ran.Next(0, 5) == 1)
                {
                    gene[i] = 1;
                }
                else
                {
                    gene[i] = 0;
                }
            }
        }
        public double GetValue()
        {
            double result = 0;
            double deltax = Math.Abs((double)(min - max) / partic);
            for (int j = 0; j < BITS_PER_GENE; j++)
            {
                result += gene[BITS_PER_GENE - j - 1] * Math.Pow(2.0, j);
            }
            result = min + (deltax * result);
            return result;
        }
        public string getGene()
        {
            string g = "";
            for (int i = 0; i < BITS_PER_GENE; i++)
            {
                g += gene[i].ToString();
            }
            return g;
        }
        public string gray()
        {
            string result = "";
            result = gene[0].ToString()+gene[1].ToString();
            for (int i = 1; i < BITS_PER_GENE - 1; i++)
            {
                if (gene[i] != gene[i + 1])
                    result += 1;
                else
                    result += 0;
            }
            return result;
        }

    }
}
