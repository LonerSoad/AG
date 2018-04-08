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
    27/Marzo/2018
    Encuentra el mínimo de la función f(x)=cos(x)*e^{-pi*x/100} en el intervalo de x [-10 a 10]

    Usa la representación real con codificación Gray.
*/
namespace FirstAGMinim
{
    class Program
    {
        static void Main(string[] args)
        {
            Individuo[] poblacion = new Individuo[100];
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 100; i++)//se genera la poblacion de 100 individuos
            {
                poblacion[i] = new Individuo(new Random(Guid.NewGuid().GetHashCode()));
                poblacion[i].setApti(Metodo.getRandom(0, 50, new Random(Guid.NewGuid().GetHashCode())));//se evalua la funcion, a minimizar , con un numero aleatorio para setear su aptitud
                                                                                                        /*Si genera la aptitud bien*/
            }
            /* for (int i = 0; i < poblacion.Length; i++)
             {
                 Console.WriteLine("Individuofirst " + (i + 1) + " : " + poblacion[i].ToString() + "\n");
             }*/
            for (int i = 0; i < 500; i++)//se van a crear 500 generaciones
            {
                //Console.WriteLine("Generacion: " + (i + 1));

                // Metodo.imprime(poblacion);
                
                poblacion = Metodo.elitismo(poblacion);
                poblacion = Metodo.Ruleta(poblacion, new Random(Guid.NewGuid().GetHashCode()));
                // Metodo.imprime(poblacion);
                //if (i == 499)
                  //  Metodo.imprime(poblacion);
                Metodo.Mutacion(poblacion, new Random(Guid.NewGuid().GetHashCode()));
               // if (i == 499)
                 //   Metodo.imprime(poblacion);
                // Console.ReadLine();
            }
            Console.WriteLine("Minimo de la funcion: f(x)=cos(x)*e^{-pi*x/100}\n ");
            Console.WriteLine(poblacion[0].ToString());
            // Metodo.imprime(poblacion);
           // Console.WriteLine("" + new Random(Guid.NewGuid().GetHashCode()).Next(0, 50));
            //Console.WriteLine("" + new Random(Guid.NewGuid().GetHashCode()).Next(0, 50));
            Console.ReadLine();
        }
    }
}

