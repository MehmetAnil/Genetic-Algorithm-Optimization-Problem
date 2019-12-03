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

            /*
            asansörFIFOyaAl(döngüSay, turistler, false);
            asansörPQyaAl(döngüSay, turistler, false);
            */

            //TURIST RANDOM NUMARALARI CROSSOVER METODUNA AKTARMA!!!!!!

            double[] toplam_süreler = new double[10];
            ArrayList NumaraListe = new ArrayList();
            
            for (int j = 0; j < 10; j++)
            {
                ArrayList deney = RandomAsansörAta(turistler);
                toplam_süreler[j] = Convert.ToDouble(deney[0]);
                NumaraListe.Add(deney[1]);
            }

            

            int sayac = 0;
            foreach (int[] item in NumaraListe)
            {
                Console.WriteLine("{1}. değer için, Toplam Süreler: {0}",toplam_süreler[sayac],sayac+1);
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item[i]);
                }
                Console.WriteLine();
                sayac++;
            }

            Console.ReadKey();
        }

        

        static ArrayList RandomAsansörAta(List<Turist> turistler)
        {
            
            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            int[] RandomNumaralar = new int[turistler.Count];
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
            double toplamSürePQ= asansörPQyaAl(PdöngüSay, PQturistler, true);

            double ToplamSüre = toplamSürePQ + toplamSüreFIFO;

            ArrayList deney_liste = new ArrayList();
            deney_liste.Add(ToplamSüre);
            deney_liste.Add(RandomNumaralar);

            int sayac3 = 0;
            foreach (Turist t in FIFOturistler)
            {
                Console.WriteLine(++sayac3 + ".ZAMANLIFIFOturist: " + t + "\n");
            }

            Console.WriteLine("_____________________________________");


            int sayac4 = 0;
            foreach (Turist t in PQturistler)
            {
                Console.WriteLine(++sayac4 + ".ZAMANLIPQturist: " + t + "\n");
            }
            return deney_liste;
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
