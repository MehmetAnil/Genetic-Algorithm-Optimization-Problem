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
        
       /*static int[] ParentSeçimi(ArrayList NumaraListe, double[] toplam_süreler)
        {
            
            

        }*/
        


        static int[] Crossover(int[] parent1, int[] parent2)
        {
            int[] child = new int[10];

            int midpoint = rd.Next(10);
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
            return child;

        }
        
    }
}
