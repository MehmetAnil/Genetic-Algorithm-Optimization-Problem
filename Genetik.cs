using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetik
{
    class Program
    {
        static Random rd = new Random();
        static void Main(string[] args)
        {

            int[] array1 = new int[10];
            int[] array2 = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int deger1 = rd.Next(0, 2);
                int deger2 = rd.Next(0, 2);
                array1[i] = deger1;
                array2[i] = deger2;
            }
            foreach (var item in array1)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            foreach (var item in array2)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            int[] child= Crossover(array1, array2);
            foreach (var item in child)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Mutate(child, 0.06);

            Console.WriteLine();

            foreach (var item in child)
            {
                Console.Write(item);
            }

            Console.ReadKey();

        }

        static int[] Crossover(int[] parent1,int[] parent2)
        {
              int[] child = new int[10];
            
              int midpoint = rd.Next(10);
              Console.WriteLine("midpoint: "+midpoint);
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
            return child;

        }

        static void Mutate(int[] child,double mutation_rate)
        {
            int rd_sayi =5;
            for (int i = 0; i < child.Length; i++)
            {
                double rd_double = rd.NextDouble();
                Console.WriteLine("Random Double: "+rd_double);
                if ((rd_double)<mutation_rate)
                {
                    
                    child[i] = rd_sayi;
                }
                Console.WriteLine("Random Sayı: {0}",rd_sayi);
            }
            
        }

    }
}
