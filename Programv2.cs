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

            Dictionary<double,int[]> deneyler =new Dictionary<double, int[]>();
            
            int sayac = 0;
            for (int i = 0; i < 10; i++)
            {
                int[] Numaralar = new int[10];
                double[] deney = RandomAsansörAta(turistler);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(deney[j]);
                    Numaralar[j] = Convert.ToInt32(deney[j]);
                    
                    
                }
                if (!deneyler.ContainsKey(deney[10]))
                {
                    deneyler.Add(deney[10], Numaralar);
                    sayac++;
                }
                Console.WriteLine();
                Console.WriteLine("Deney Süre: " + deney[10]);
            }
            Console.WriteLine("Sayac: "+sayac);


            
            int[] çocuk = GenetikAlgoritma.ParentSeçimi(deneyler);
            
            Console.WriteLine("Çocuk İndex: ");
            foreach (int i in çocuk)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            double çocuk_toplamSüre = ÇocukAsansörAta(çocuk, turistler);
            Console.WriteLine("Çocuk Toplam Süre: "+çocuk_toplamSüre);

            Console.ReadKey();
        }






        static double[] RandomAsansörAta(List<Turist> turistler)
        {

            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            double[] RandomNumaralar = new double[turistler.Count + 1];
            int index = 0;
            
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
            
            int FdöngüSay = (int)Math.Ceiling((double)FIFOturistler.Count / 4);
            double toplamSüreFIFO = asansörFIFOyaAl(FdöngüSay, FIFOturistler, true);

            int PdöngüSay = (int)Math.Ceiling((double)PQturistler.Count / 4);
            double toplamSürePQ = asansörPQyaAl(PdöngüSay, PQturistler, true);

            double ToplamSüre = toplamSürePQ + toplamSüreFIFO;
            Console.WriteLine();
            RandomNumaralar[10] = ToplamSüre;
            return RandomNumaralar;
        }

        static double ÇocukAsansörAta(int[] çocuk, List<Turist> turistler)
        {
            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            int sayac = 0;
            foreach(Turist t in turistler)
            {
                if (çocuk[sayac] == 0)
                {
                    t.setRandomNo = 0;
                    FIFOturistler.Add(t);
                }
                else if(çocuk[sayac]==1)
                {
                    t.setRandomNo = 1;
                    PQturistler.Add(t);
                }
                sayac++;
            }
            int FdöngüSay = (int)Math.Ceiling((double)FIFOturistler.Count / 4);
            double toplamSüreFIFO = asansörFIFOyaAl(FdöngüSay, FIFOturistler, true);

            int PdöngüSay = (int)Math.Ceiling((double)PQturistler.Count / 4);
            double toplamSürePQ = asansörPQyaAl(PdöngüSay, PQturistler, true);

            double ToplamSüre = toplamSürePQ + toplamSüreFIFO;
            Console.WriteLine("TOPLAM SÜRE: "+ToplamSüre);
            return ToplamSüre;
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
