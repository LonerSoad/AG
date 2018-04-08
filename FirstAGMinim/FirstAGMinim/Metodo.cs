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
    public class Metodo
    {
        //public static Random ran = new Random(Guid.NewGuid().GetHashCode());

        /* public static Individuo[] Ruleta(Individuo[] poblacion, Random ran)
         {
             Individuo[] new_pob = new Individuo[poblacion.Length];

             double[] Ve = new double[poblacion.Length];//Array de valores esperados
             double frec = .01;//Frecuencia esperada
             double sum_apt = 0.0;//suma de aptitudes
             double T = 0.0;//variable maxima para generar numeros entre 0 y T
             double r = 0.0;//valor generado entre 0 y T
             double acumula = 0.0;

             //  Console.WriteLine("Bef Frec " + frec);
             foreach (Individuo indi in poblacion)
                 sum_apt += indi.getApti();

             //Console.WriteLine("Suma  " + sum_apt);
             frec *= sum_apt;

             //Console.WriteLine("Se Frec "+frec );
             for (int i = 0; i < Ve.Length; i++)
             {
                 Ve[i] = poblacion[i].getApti() * frec;
                 T += Ve[i];
             }
             int conta = 0;
             //Console.WriteLine("T: " + T);
             while (new_pob[99] == null)
             {
                 // Console.WriteLine(";");
                 r = getRandom(0, 1, ran);
                 //Console.WriteLine("Se entra con -> " + r+"  "+conta);
                 for (int i = 0; i < poblacion.Length; i++)
                 {

                     acumula += poblacion[i].getApti();
                     if (r < acumula)
                     {

                         new_pob[conta] = poblacion[i];
                         // Console.WriteLine("Se selecciona -> " +i+"   ");
                         acumula = 0.0;
                         conta += 1;
                         break;
                     }

                 }
             }*/
        /*   if (new_pob[new_pob.Length - 1] == null)//esto era para comprobar si un array esta lleno
               Console.WriteLine("Tam: " + new_pob.Length);
           */
        //   return new_pob;

        // }

        /********************************************************/
        public static Individuo[] Ruleta(Individuo[] poblacion, Random ran)
        {
            Individuo[] new_pob = new Individuo[poblacion.Length];

            double[] Ve = new double[poblacion.Length];//Array de valores esperados
            double frec = .01;//Frecuencia esperada
            double sum_apt = 0.0;//suma de aptitudes
            double T = 0.0;//variable maxima para generar numeros entre 0 y T
            double r = 0.0;//valor generado entre 0 y T
            double acumula = 0.0;
            foreach (Individuo indi in poblacion)
                sum_apt += indi.getApti();

            frec *= sum_apt;
            
            for (int i = 0; i < Ve.Length; i++)
            {
                Ve[i] = poblacion[i].getApti() * frec;
                T += Ve[i];
            }
            int conta = 0;
            Individuo[] selecc = new Individuo[2];//Arreglo de los dos individuos seleccionados(Padre y madre)
            selecc[0] = null;
            selecc[1] = null;
            while (new_pob[98] == null )//se llenan las primeras 98 posiciones para reservar la ultima ,para el elemento mas apto separado por el proceso del elitismo 
            {
                while(selecc[1] == null)
                for (int elem = 0; elem < 2; elem++)//se hace dos veces
                { 
                    r = getRandom(0, T, ran);//se genera el random
                    for (int i = 0; i < poblacion.Length; i++)
                    {//se realiza N veces (Donde N es el size de la poblacion)

                        acumula += poblacion[i].getApti();//acumulador de la suma de aptitudes
                        if (acumula >= r)//Recorrer los individuos sumando las ap)tudes, detenerse hasta que la
                                        //suma de las aptitudes sea mayor o igual a r(elegir a ese individuo)
                        {
                            //Console.WriteLine("Se elige a un Individuo ");
                           // new_pob[conta] = poblacion[i];
                            selecc[elem] = poblacion[i];//se asigna el individuo seleccionado a el arreglo que almacenara a los seleccionados
                            acumula = 0.0;//reseteo el acumulador de las aptitudes
                         //   conta += 1;
                            break;
                        }

                    }
                }
                /*Create Offspring*/
                selecc = selecc[0].Cross1P(selecc[1]);//se realiza la CRUZA de los dos individuos seleccionados , y los hijos que se retornan
                //sobreescriben a el padre y madre en el arreglo
                new_pob[conta] = selecc[0];//se agrega a la nueva poblacion el primer hijo 
                conta = conta + 1;//se incrementa el contador 
                new_pob[conta] = selecc[1];//se agrega a la nueva poblacion el segundo hijo
                conta = conta + 1;//se incrementa el contador 

                /*****************/
            }
            
            if (new_pob[new_pob.Length - 1] == null)//esto era para comprobar si un array esta lleno
                Console.WriteLine("Tam: " + new_pob.Length);
            new_pob[99] = poblacion[99];//se guarda el elemento sacado del elitismo en la ultimaposicion de la nueva poblacion
            return new_pob;

         }
            /*************************************************************/

        public static void Mutacion(Individuo[] poblacion, Random ran)
        {
            //Individuo[] poblacion = poblac;
            // Console.WriteLine("" + poblac.Length + " : " + poblacion.Length);
            /*Solo se va a mutar un 10% de la poblacion*/
            int porcent = (10 * poblacion.Length) / 100;
            //Console.WriteLine("Porcentaje de mutacion:  " + porcent);
            for (int i = 0; i < porcent; i++)
            {
                if (ran.Next(0, 10) == 1)//si se igual a uno , significa que el individuo va a ser mutado
                {
                    //Console.WriteLine("Hay mutacion");
                    int tama = poblacion[i].elcromosoma.gen.BITS_PER_GENE;//get tamaño de el gene
                    int punto = ran.Next(0, tama - 1);
                    poblacion[i].elcromosoma.gen.gene[punto] = ((poblacion[i].elcromosoma.gen.gene[punto] == 1)) ? 0 : 1;
                    // break;//el inidividuo ya se muto en un solo punto como debe de ser así que se termina 
                    // poblacion[i].elcromosoma.gen[0].gene[j] = ((ran.Next(0, 2) == 1)) ? 1 : poblacion[i].elcromosoma.gen[0].gene[j];

                }
            }


        }
        public static double getRandom(double minimum, double maximum, Random ran)
        {
            return ran.NextDouble() * (maximum - minimum) + minimum;
        }

        public static void imprime(Individuo[] poblacion)
        {
            for (int i = 0; i < poblacion.Length; i++)
            {
                Console.WriteLine("Individuo " + (i + 1) + " : " + poblacion[i].elcromosoma.gen.GetValue()+ "\n");
            }
        }


        public static Individuo[] elitismo(Individuo[] poblacion)
        {
            Individuo[] new_pob = new Individuo[100];
            for (int i = 0; i < 100; i++)
                new_pob[i] = poblacion[i];
            //bubbleSort(poblacion);
            quicksort(poblacion,0,99);
            new_pob[99] = poblacion[0];//se guarda el de menor valor en la penultima posicion de la nueva poblacion

          //  imprime(poblacion);
            return new_pob;

        }
        public static void bubbleSort(Individuo[] poblacion)
        {
            Individuo aux = null;
            for (int i = 0; i < poblacion.Length - 1; i++)
                for (int j = 0; j < poblacion.Length - i - 1; j++)
                    if (poblacion[j].elcromosoma.gen.GetValue() > poblacion[j + 1].elcromosoma.gen.GetValue())
                    {
                         aux = poblacion[j];
                        poblacion[j] = poblacion[j + 1];
                        poblacion[j + 1] = aux;
                    }
        }

        public static void quicksort(Individuo[] poblacion,int primero,int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = poblacion[central].elcromosoma.gen.GetValue();
            i = primero;
            j = ultimo;
            do
            {
                while (poblacion[i].elcromosoma.gen.GetValue() < pivote) i++;
                while (poblacion[j].elcromosoma.gen.GetValue() > pivote) j--;
                if (i <= j)
                {
                    Individuo temp;
                    temp = poblacion[i];
                    poblacion[i] = poblacion[j];
                    poblacion[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (primero < j)
            {
                quicksort(poblacion, primero, j);
            }
            if (i < ultimo)
            {
                quicksort(poblacion, i, ultimo);
            }
        }
    }

}
    
