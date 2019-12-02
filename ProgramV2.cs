using System;
using System.Collections;
using System.Collections.Generic;


namespace Proje2A1
{
    class Program
    {
        static Random rand = new Random();

        public static void Main(string[] args)
        {
            List<Turist> turistler = new List<Turist>();
            turistOluştur(turistler);
            
            int döngüSay = (int)Math.Ceiling((double)turistler.Count / 4);

           AsansörFIFOyaAl(döngüSay, turistler);
           AsansörPQyaAl(döngüSay, turistler);

        Console.WriteLine("\n"+"-----------------------------");

            //RANDOM ASANSÖRLER

            RandomAsansörAta(turistler);



            
        Console.ReadKey();

        }

        static void RandomAsansörAta(List<Turist> turistler)
        {
            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            foreach(Turist t in turistler)
            {
                int asansör_no = rand.Next(0, 2);
                if (asansör_no == 0)
                {
                    FIFOturistler.Add(t);
                }
                else if (asansör_no == 1)
                {
                    PQturistler.Add(t);
                }

            }
            Console.WriteLine("\n"+"RANDOM ASANSOR TURIST-----");
            int Fdöngüsay = (int)Math.Ceiling((double)FIFOturistler.Count / 4);
            AsansörFIFOyaAl(Fdöngüsay, FIFOturistler);
           
            foreach (var i in FIFOturistler)
            {
                Console.WriteLine("////////////////"+i);
            }

            int PdöngüSay = (int)Math.Ceiling((double)PQturistler.Count / 4);
            AsansörPQyaAl(PdöngüSay, PQturistler);
            
            foreach (var i in PQturistler)
            {
                Console.WriteLine("+++++++++++++++++"+i);
            }

        }
        static void AsansörFIFOyaAl(int döngü,List<Turist> turistler)
        {
            

            AsansörFIFO asansörFIFO = new AsansörFIFO();

            for (int i = 0; i < turistler.Count; i++)
            {
                asansörFIFO.Enqueue(turistler[i]);

            }
            for (int i = 0; i < döngü; i++)
            {
                asansörFIFO.FIFOsüre(asansörFIFO);
            }
            
        }

        static void AsansörPQyaAl(int döngü, List<Turist> turistler)
        {
            AsansörPQ asansörPQ = new AsansörPQ();
            

            for (int j = 0; j < turistler.Count; j++)
            {
                asansörPQ.Enqueue(turistler[j]);
            }

            for (int i = 0; i < döngü; i++)
            {
                asansörPQ.PQsüre(asansörPQ);
            }
        }


        static void turistOluştur(List<Turist> turistler)
        {

            int[] kat = { 3, 8, 8, 4, 4, 1, 1, 3, 2, 5,6,8,1,5,7,6,3,7,2,7 };

            for (int i = 0; i < kat.Length; i++)
            {
                Turist turist = new Turist(kat[i], i, nameGenerator()); //sonra kat sayısına rand.Next(0, 9) yaz
                turistler.Add(turist);
            }

        }

        static String nameGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[5];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }
            String name = new String(stringChars);
            return name;
        }


    }

}
