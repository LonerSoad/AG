using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Universidad Autonoma Del Estado de Mexico
    C.U. UAEM Zumpango 
    Ingenieria en Computacion
    Algoritmos Geneticos
    Juan Carlos Angeles Vazquez
    07/Abril/2018
    Encuentra el mínimo de la función f(x)=cos(x)*e^{-pi*x/100} en el intervalo de x [-10 a 10]

    Usa la representación real con codificación Gray.
*/
namespace FirstAGMinim
{
    public class Cromosoma
    {



        public Gen gen;
        public Cromosoma(Random ran)
        {

            gen = new Gen(-10, 10, 128);//de -10 a 10 con 128 particiones
            gen.inicializa(new Random(Guid.NewGuid().GetHashCode())); 
        }


        public override string ToString()
        {
            string cadena = "Cromosoma [";

            
            cadena += gen.gray()+"]  -> "+gen.GetValue();
            return cadena;
        }

        public int[] getGene()
        {
            return gen.gene;
        }

    }
}
