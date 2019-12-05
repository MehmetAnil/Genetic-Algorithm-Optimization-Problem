using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Proje2A1
{
    class GenetikAlgoritma
    {
        static readonly Random rd = new Random();

        public static int[] ÇocukBelirle(int[] parent1,int[]parent2)//Prante Indexleri parametre olarak verilecek
        {
            
            
            Console.WriteLine("\nParent1 Index: ");
            for (int i = 0; i < parent1.Length; i++)
            {
                Console.Write(parent1[i]);
            }
           
            Console.WriteLine("\nprante2 Index: ");
            for (int i = 0; i < parent2.Length; i++)
            {
                Console.Write(parent2[i]);
            }
            
            
            int[] çocuk = Crossover(parent1, parent2);

            return çocuk;

        }
        static int[] Crossover(int[] parent1, int[] parent2)
        {
            int[] child = new int[parent1.Length];
            

            int midpoint = rd.Next(1,parent1.Length-1);
            Console.WriteLine("\tmidpoint: " + midpoint);
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
            Mutate(child, 0.4);
            return child;

        }
        static void Mutate(int[] child, double mutation_rate)
        {
            
            for (int i = 0; i < child.Length; i++)
            {
                int rd_sayi = rd.Next(0, 2);
                double rd_double = rd.NextDouble();
               // Console.WriteLine("Random Double: " + rd_double);
                if ((rd_double) < mutation_rate)
                {

                    child[i] = rd_sayi;
                   //Console.WriteLine("Mutasyon: "+i);
                }
                //Console.WriteLine("Random Sayı: {0}", rd_sayi);
            }

        }
        
        public static int[] ParentBelirle(List<DNA> popülasyon)
        {
            popülasyon.Sort((x,y) => x.getSüre.CompareTo(y.getSüre));
            
            

            int[] parent1= popülasyon[1].getNumaralar;
            int[] parent2= popülasyon[2].getNumaralar;

            Console.WriteLine("P1:  "+popülasyon[0].getSüre+"\nP2:   "+ popülasyon[1].getSüre);

            int[] çocuk=ÇocukBelirle(parent1, parent2);
            
            
            return çocuk;

        }


    }
}
