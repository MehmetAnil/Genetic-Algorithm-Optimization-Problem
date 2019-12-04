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

        public static int[] ParentSeçimi(double[,] toplam_süreler)
        {
            double[] min_süreler = new double[10];
            for (int i = 0; i < 10; i++)
            {
                min_süreler[i] = toplam_süreler[i, 10];
            }
            Array.Sort(min_süreler);

            int[] parent1 = new int[10];
            int[] parent2 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(min_süreler[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                if (toplam_süreler[i, 10] == min_süreler[0])
                {
                    for (int j = 0; j < 10; j++)
                    {
                        parent1[j] = Convert.ToInt32(toplam_süreler[i, j]);
                    }
                }
                else if (toplam_süreler[i, 10] == min_süreler[1])
                {
                    for (int j = 0; j < 10; j++)
                    {
                        parent2[j] = Convert.ToInt32(toplam_süreler[i, j]);
                    }
                }
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
                Mutate(child, 0.06);
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
                }
                Console.WriteLine("Random Sayı: {0}", rd_sayi);
            }

        }
    }
}
