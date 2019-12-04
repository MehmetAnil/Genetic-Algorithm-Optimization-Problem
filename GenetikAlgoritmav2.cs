using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2A1
{
    class GenetikAlgoritma
    {
        static readonly Random rd = new Random();

        public static int[] ParentSeçimi(Dictionary<double, int[]> deneyler)
        {
            int[] parent1 = new int[10];
            int[] parent2 = new int[10];



            List<double> val = deneyler.Keys.ToList();
            val.Sort();
            
            double key1 = val[0];
            double key2 = val[1];
            Console.WriteLine("Parent1: " + key1 + "Parent2: " + key2);

            
            parent1 = deneyler[key1];
            parent2 = deneyler[key2];
            
            Console.WriteLine("Parent1 Index: ");
            for (int i = 0; i < parent1.Length; i++)
            {
                Console.Write(parent1[i]);
            }
            Console.WriteLine("prante2 Index: ");
            for (int i = 0; i < parent2.Length; i++)
            {
                Console.Write(parent2[i]);
            }

            
            int[] çocuk = Crossover(parent1, parent2);

            return çocuk;

        }
        static int[] Crossover(int[] parent1, int[] parent2)
        {
            int[] child = new int[10];

            int midpoint = rd.Next(1,8);
            Console.WriteLine("midpoint: " + midpoint);
            for (int i = 0; i < child.Length; i++)
            {
                if (i < midpoint)
                {
                    child[i] = parent1[i];
                }
                else
                {
                    child[i] = parent2[i];
                }
            }
            Mutate(child, 0.3);
            return child;

        }
        static void Mutate(int[] child, double mutation_rate)
        {
            
            for (int i = 0; i < child.Length; i++)
            {
                int rd_sayi = rd.Next(0, 2);
                double rd_double = rd.NextDouble();
                Console.WriteLine("Random Double: " + rd_double);
                if ((rd_double) < mutation_rate)
                {

                    child[i] = rd_sayi;
                    Console.WriteLine("Mutasyon: "+i);
                }
                Console.WriteLine("Random Sayı: {0}", rd_sayi);
            }

        }
     
    }
}
