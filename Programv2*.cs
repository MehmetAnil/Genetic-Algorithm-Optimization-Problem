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

            
            /*asansörFIFOyaAl(döngüSay, turistler, false);
            asansörPQyaAl(döngüSay, turistler, false);
            */

            //TURIST RANDOM NUMARALARI CROSSOVER METODUNA AKTARMA!!!!!!

            double[,] toplam_süreler = new double[10, 11];

            
            for (int i = 0; i < 10; i++)
            {
                double[] deney = RandomAsansörAta(turistler,true);
                for (int j = 0; j < 11; j++)
                {
                    
                    toplam_süreler[i, j] = deney[j];


                }
            }
            

            
            int[] çocuk = GenetikAlgoritma.ParentSeçimi(toplam_süreler);

            for (int i = 0; i < 10; i++)
            {
                turistler[i].setRandomNo = çocuk[i];
            }
            

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" değer için, Toplam Süreler: {0}", toplam_süreler[i, 10]);
                for (int j = 0; j < 11; j++)
                {
                    
                    Console.Write(toplam_süreler[i, j]);
                }
                Console.WriteLine();
                
            }
            Console.WriteLine("YENİ DEĞER---------------");
            RandomAsansörAta(turistler,false);
            
            Console.ReadKey();
        }






        static double[] RandomAsansörAta(List<Turist> turistler, bool kontrol1)
        {

            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            double[] RandomNumaralar = new double[turistler.Count + 1];
            int index = 0;
            if (kontrol1) {
                foreach (Turist t in turistler)
                {

                    int asansör_no = rand.Next(0, 2);
                    switch (asansör_no)
                    {
                        case 0:
                            FIFOturistler.Add(t);
                            t.setRandomNo = 0;
                            break;
                        case 1:
                            PQturistler.Add(t);
                            t.setRandomNo = 1;
                            break;
                    }
                    RandomNumaralar[index] = asansör_no;
                    index++;
                }
            } 

            int FdöngüSay = (int)Math.Ceiling((double)FIFOturistler.Count / 4);
            double toplamSüreFIFO = asansörFIFOyaAl(FdöngüSay, FIFOturistler, true);

            int PdöngüSay = (int)Math.Ceiling((double)PQturistler.Count / 4);
            double toplamSürePQ = asansörPQyaAl(PdöngüSay, PQturistler, true);

            double ToplamSüre = toplamSürePQ + toplamSüreFIFO;
            Console.WriteLine();
            RandomNumaralar[10] = ToplamSüre;
            Console.WriteLine(ToplamSüre);
            int sayac3 = 0;
           /* foreach (Turist t in FIFOturistler)
            {
                Console.WriteLine(++sayac3 + ".ZAMANLIFIFOturist: " + t + "\n");
            }*/

            Console.WriteLine("_____________________________________");


            int sayac4 = 0;
            /*foreach (Turist t in PQturistler)
            {
                Console.WriteLine(++sayac4 + ".ZAMANLIPQturist: " + t + "\n");
            }*/
            return RandomNumaralar;
        }

        static double asansörFIFOyaAl(int döngüSay, List<Turist> turistler, bool rnd_kontrol)
        {
            AsansörFIFO asansörFIFO = new AsansörFIFO();
            double toplamSüreFIFO = 0;

            for (int i = 0; i < turistler.Count; i++)
            {
                asansörFIFO.Enqueue(turistler[i]);
            }

            double toplamSüreGrup = 0;
            for (int i = 0; i < döngüSay; i++)
            {
                toplamSüreGrup = asansörFIFO.FIFOsüre(asansörFIFO, rnd_kontrol);
                toplamSüreFIFO += toplamSüreGrup;
            }

            return toplamSüreFIFO;
        }

        static double asansörPQyaAl(int döngüSay, List<Turist> turistler, bool rnd_kontrol)
        {
            AsansörPQ asansörPQ = new AsansörPQ();
            double toplamSürePQ = 0;

            for (int i = 0; i < turistler.Count; i++)
            {
                asansörPQ.Enqueue(turistler[i], turistler[i].getKatNo);
            }
            double toplamSüreGrup = 0;
            for (int i = 0; i < döngüSay; i++)
            {
                toplamSüreGrup = asansörPQ.PQsüre(asansörPQ, rnd_kontrol);
                toplamSürePQ += toplamSüreGrup;
            }

            return toplamSürePQ;
        }

        static void turistOluştur(List<Turist> turistler)
        {
            int[] kat = { 3, 8, 8, 4, 4, 1, 1, 3, 2, 5 };
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
