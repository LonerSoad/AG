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
    public class Individuo
    {
        double apti = 0;
        public Cromosoma elcromosoma; 
        public Individuo(Random ran)
        {
            this.elcromosoma = new Cromosoma(ran);            
        }


        public double getApti()
        {
            return apti;

        }

        public void setApti(double x)//Aptitud
        {
            double Fx = 0.0;
            Fx = Math.Cos(x) * Math.Pow(Math.E, (-(Math.PI * x) / 100));
            // apti = 1 / Fx;//para obtener la apitud de la funcion
            apti = Fx;
        }

        public override string ToString()
        {
            return string.Format(elcromosoma.ToString());
        }

        public Individuo[] Cross1P(Individuo madre)
        {
           // Console.WriteLine(madre);
            Individuo[] hijos = new Individuo[2];
            hijos[0] = new Individuo(new Random(Guid.NewGuid().GetHashCode()));

            hijos[1] = new Individuo(new Random(Guid.NewGuid().GetHashCode()));
            //padre es el que llama al metodo
            int crosspoint = new Random(Guid.NewGuid().GetHashCode()).Next(3, 5);
           // Console.WriteLine("\nPunto: " + crosspoint + "\n");
            for (int i = 0; i < madre.elcromosoma.gen.BITS_PER_GENE; i++)
            {
                hijos[0].elcromosoma.getGene()[i] = (i <= crosspoint) ? this.elcromosoma.getGene()[i] : madre.elcromosoma.getGene()[i];

                hijos[1].elcromosoma.getGene()[i] = (i <= crosspoint) ? madre.elcromosoma.getGene()[i] : this.elcromosoma.getGene()[i];
            }

            return hijos;
        }
    }
}
