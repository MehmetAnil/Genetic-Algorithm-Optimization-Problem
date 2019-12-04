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

        public static int[] ÇocukBelirle(Dictionary<double, int[]> deneyler)//Prante Indexleri parametre olarak verilecek
        {
            
            List<double> val = deneyler.Keys.ToList();
            val.Sort();
            double key1 = val[0]; //1. parent index
            double key2 = val[1]; //2. parent index
            Console.WriteLine("Parent1: " + key1 + "Parent2: " + key2);

            
            int[] parent1 = deneyler[key1];
            int[] parent2 = deneyler[key2];
            
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
            Mutate(child, 0.05);
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
        
        static Dictionary<double,double> CalcFitness(Dictionary<double, int[]> deneyler)
        {
            List<double> val = deneyler.Keys.ToList();
            Dictionary<double, double> Olasılıklar = new Dictionary<double, double>();

            double toplamSüre = 0;
            for (int i = 0; i < val.Count; i++)
            {
                toplamSüre += val[i];
            }
            for (int j = 0; j <val.Count; j++)
            {
                Olasılıklar.Add(val[j], toplamSüre / val[j]);
            }
            return Olasılıklar;
        }
        static void ParentBelirle(Dictionary<double,double> Olasılıklar)
        {
            ArrayList MatingPool = new ArrayList();

            for (int i = 0; i < Olasılıklar.Count; i++)
            {

            }
        }
        

    }
}
