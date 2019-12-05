using System;
using System.Collections.Generic;
using System.Linq;


namespace Proje2A1
{
    class Program
    {
        static readonly Random rand = new Random();

        public static void Main(string[] args)
        {
            List<Turist> turistler = new List<Turist>();

            turistOluştur(turistler);

            oitsYazdır(turistler);
            tabloYazdır(turistler);


            //int döngüSay = (int)Math.Ceiling((double)turistler.Count / 4);
            //asansörFIFOyaAl(döngüSay, turistler, false);
            //asansörPQyaAl(döngüSay, turistler, false);

            //foreach (var turist in turistler)
            //{
            //    Console.WriteLine(turist);
            //    Console.WriteLine();
            //}

            
            List<DNA> popülasyon = new List<DNA>();
            popülasyon=(deneySetiOluştur(turistler));

            GenetikAlgoritmaÇalıştır(popülasyon, turistler,20);



            Console.ReadKey();
        }

        static void oitsYazdır(List<Turist> turistler)
        {
            Console.WriteLine("Numara\tİsim\tKat Numarası\t" +
                "Sadece FIFO ITS\tSadece PQ ITS\tRandom ITS");
            int döngüSay = (int)Math.Ceiling((double)turistler.Count / 4);

            double FIFOtoplam = asansörFIFOyaAl(döngüSay, turistler, false);
            double PQtoplam = asansörPQyaAl(döngüSay, turistler, false);
            double Randomtoplam = RandomAsansörAta(turistler)[turistler.Count];

            foreach (Turist t in turistler)
            {
                Console.WriteLine(t.toString());
            }

            Console.WriteLine("\nFIFO OITS: {0} saniye", FIFOtoplam / turistler.Count);
            Console.WriteLine("PQ OITS: {0} Saniye", PQtoplam / turistler.Count);
            Console.WriteLine("Random OITS: {0} Saniye\n", Randomtoplam / turistler.Count);
        }


        static void tabloYazdır(List<Turist> turistler)

            
        {
            Console.WriteLine("Numara\tPQ'nun FIFO'ya göre Süre Kazancı\tRandom durumun FIFO'ya göre Süre Kazancı");
            for (int i = 0; i < turistler.Count; i++)
            {
                double ilk_durum = turistler[i].getFIFOsüre - turistler[i].getPQsüre;
                double ikinci_durum = turistler[i].getFIFOsüre - turistler[i].getRandomSüre;
                Console.WriteLine(turistler[i].getNumara + "\t" + ((ilk_durum)<0 ? Math.Abs((ilk_durum)) + "\tSaniye Kaybedildi." : Math.Abs((ilk_durum)) + "\tSaniye Kazanıldı.") + "\t\t" + (ikinci_durum<0 ? Math.Abs(ikinci_durum) + "\tSaniye Kaybedildi." : Math.Abs(ikinci_durum) + "\tSaniye Kazanıldı."));
            }
        }

        static List<DNA> deneySetiOluştur(List<Turist> turistler)
        {
            List<DNA> popülasyon = new List<DNA>();
            DNA birey = null;

           
            for (int i = 0; i < 30; i++) //n adet olmasını buradan ayarla
            {
                
                int[] numaralar = new int[turistler.Count];
                double[] deney = RandomAsansörAta(turistler); //ilk n adet veri setini oluşturur

                for (int j = 0; j < turistler.Count; j++)
                {
                     //deney setini gösterir
                    numaralar[j] = Convert.ToInt32(deney[j]);
                }
                birey = new DNA(deney[turistler.Count], numaralar);

                Console.WriteLine();
                Console.WriteLine("Deney Süre: " + deney[turistler.Count]);
                popülasyon.Add(birey);
            }
            
          

            return popülasyon;
        }

        public static void GenetikAlgoritmaÇalıştır(List<DNA> popülasyon, List<Turist> turistler, int generasyonSay) //int n: generasyon sayısı
        {
            
            for (int i = 0; i < generasyonSay; i++)
            {
                int[] çocuk = GenetikAlgoritma.ParentBelirle(popülasyon);

                 Console.Write("\nÇocuk İndex: ");
                 foreach (int j in çocuk)
                 {
                     Console.Write(j);
                 }
                 Console.WriteLine();
                double çocuk_toplamSüre = ÇocukAsansörAta(çocuk, turistler);
                 Console.WriteLine("++++++++++Çocuk Toplam Süre: " + çocuk_toplamSüre+"\n");

                popülasyonDeğiştir(çocuk_toplamSüre, çocuk, popülasyon);

            }

        }


        static List<DNA> popülasyonDeğiştir(double çocuk_toplamSüre, int[] çocuk, List<DNA> popülasyon)
        {
            
            popülasyon.Sort((y, x) => x.getSüre.CompareTo(y.getSüre));

            popülasyon.Remove(popülasyon[0]);    //en kötü prante
            DNA birey = new DNA(çocuk_toplamSüre,çocuk);

            popülasyon.Sort((x,y) => x.getSüre.CompareTo(y.getSüre));

            int flag = 0;
            foreach (DNA item in popülasyon)
            {
                if (item.getSüre > çocuk_toplamSüre)
                    flag++;

            }
            if (flag > 3)
                popülasyon.Add(birey);





            return popülasyon;
        }

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

            double toplamSüre = toplamSürePQ < toplamSüreFIFO ? toplamSüreFIFO : toplamSürePQ;
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

            double toplamSüre = toplamSürePQ < toplamSüreFIFO ? toplamSüreFIFO : toplamSürePQ;
            randomNumaralar[turistler.Count] = toplamSüre;

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
                //bu kısımda değişen olmayacak 
                toplamSüreGrup = asansörFIFO.FIFOsüre(asansörFIFO, rnd_kontrol, toplamSüreGrup); //3-8-8-4ün toplam süresi, 3.parametre toplamSüreGrup olacak 
                toplamSüreFIFO += toplamSüreGrup; //tüm grupları toplar
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
                toplamSüreGrup += asansörPQ.PQsüre(asansörPQ, rnd_kontrol, toplamSüreGrup);
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
