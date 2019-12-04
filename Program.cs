using Proje2A1;
using System;
using System.Collections;
using System.Collections.Generic;


namespace QueueSimulation
{
    class Program
    {
        static Random rand = new Random();

        public static void Main(string[] args)
        {
            List<Turist> turistler = new List<Turist>();

            turistOluştur(turistler);

            int döngüSay = (int)Math.Ceiling((double)turistler.Count / 4);
            asansörFIFOyaAl(döngüSay, turistler, false);
            Console.WriteLine();
            asansörPQyaAl(döngüSay, turistler, false);

           /* Dictionary<double, int[]> deneyler = deneySetiOluştur(turistler);
            çocukOluştur(deneyler, turistler);*/

            Console.ReadKey();
        }

        static Dictionary<double, int[]> deneySetiOluştur(List<Turist> turistler)
        {
            Dictionary<double, int[]> deneyler = new Dictionary<double, int[]>(); //Key: deney süresi, Value: 0010010..

            int sayac = 0;
            for (int i = 0; i < 10; i++) //n adet olmasını buradan ayarla
            {
                int[] numaralar = new int[turistler.Count]; //DEĞİŞTİ
                double[] deney = RandomAsansörAta(turistler); //ilk n adet veri setini oluşturur

                for (int j = 0; j < turistler.Count; j++)
                {
                    Console.Write(deney[j]); //deney setini gösterir
                    numaralar[j] = Convert.ToInt32(deney[j]);
                }
                if (!deneyler.ContainsKey(deney[10]))
                {
                    deneyler.Add(deney[10], numaralar);
                    sayac++;
                }
                Console.WriteLine();
                Console.WriteLine("Deney Süre: " + deney[10]);
            }
            Console.WriteLine("\nSayaç: " + sayac);

            return deneyler;
        }

        static void çocukOluştur(Dictionary<double, int[]> deneyler, List<Turist> turistler)
        {
            int[] çocuk = GenetikAlgoritma.ÇocukBelirle(deneyler);

            Console.Write("\nÇocuk İndex: ");
            foreach (int i in çocuk)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            double çocuk_toplamSüre = ÇocukAsansörAta(çocuk, turistler);
            Console.WriteLine("Çocuk Toplam Süre: " + çocuk_toplamSüre);
        }

        //return edilen double[] olmayacak mı asansör ata da olduğu gibi??
        static double ÇocukAsansörAta(int[] çocuk, List<Turist> turistler)
        {
            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            int index = 0;
            foreach (Turist t in turistler)
            {
                if (çocuk[index] == 0)
                {
                    t.setRandomNo = 0;
                    FIFOturistler.Add(t);
                }
                else if (çocuk[index] == 1)
                {
                    t.setRandomNo = 1;
                    PQturistler.Add(t);
                }
                index++;
            }
            int FdöngüSay = (int)Math.Ceiling((double)FIFOturistler.Count / 4);
            double toplamSüreFIFO = asansörFIFOyaAl(FdöngüSay, FIFOturistler, true);

            int PdöngüSay = (int)Math.Ceiling((double)PQturistler.Count / 4);
            double toplamSürePQ = asansörPQyaAl(PdöngüSay, PQturistler, true);

            double toplamSüre = toplamSürePQ + toplamSüreFIFO;
            return toplamSüre;
        }



        static double[] RandomAsansörAta(List<Turist> turistler)
        {
            List<Turist> FIFOturistler = new List<Turist>();
            List<Turist> PQturistler = new List<Turist>();

            double[] randomNumaralar = new double[turistler.Count + 1];
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
                randomNumaralar[index] = asansör_no;
                index++;
            }

            int FdöngüSay = (int)Math.Ceiling((double)FIFOturistler.Count / 4);
            double toplamSüreFIFO = asansörFIFOyaAl(FdöngüSay, FIFOturistler, true);

            int PdöngüSay = (int)Math.Ceiling((double)PQturistler.Count / 4);
            double toplamSürePQ = asansörPQyaAl(PdöngüSay, PQturistler, true);

            double toplamSüre = toplamSüreFIFO + toplamSürePQ;
            randomNumaralar[10] = toplamSüre;

            return randomNumaralar;
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
                toplamSüreGrup += asansörFIFO.FIFOsüre(asansörFIFO, rnd_kontrol,toplamSüreGrup);
                toplamSüreFIFO += toplamSüreGrup;
            }

            foreach (Turist t in turistler)
            {
                Console.WriteLine(t.ToString());
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
                toplamSüreGrup += asansörPQ.PQsüre(asansörPQ, rnd_kontrol,toplamSüreGrup);
                toplamSürePQ += toplamSüreGrup;
            }
            
            foreach (Turist t in turistler)
            {
                Console.WriteLine(t.ToString());
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
