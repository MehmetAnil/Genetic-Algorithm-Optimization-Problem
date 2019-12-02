using System;
using System.Collections;
using System.Collections.Generic;


namespace Proje2A1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Turist nesnesini oluşturma
            List<Turist> TuristOlustur()
            {
                int[] katlar = { 3, 8, 8, 4, 4, 1, 1, 3, 2, 5, 6, 8, 1, 5, 7, 6, 3, 7, 2, 7 };
                List<Turist> tur_list = new List<Turist>();
                Random rd = new Random();
                String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                char[] stringChars = new char[6];
                
                for (int x = 0; x < 20; x++)
                {
                    
                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[rd.Next(chars.Length)];
                    }
                    string ad = new string(stringChars);
                    

                    Turist turist = new Turist(ad, x + 1, katlar[x]);
                    tur_list.Add(turist);


                }
                return tur_list;
            }

            void AsansorNumaraVer(List<Turist> l1, int asansor_say)
            {
                Random rd = new Random();
                foreach(Turist t in l1)
                {
                    int asansor_no = rd.Next(0, asansor_say);
                    t.Asansor_no = asansor_no;

                }
            }
            //TURISTLERIN OLUSTURULUP LISTELERE AKTARILDIGI KISIM
            
            List<Turist> turistler = new List<Turist>();
            turistler=TuristOlustur();
            AsansorNumaraVer(turistler, 2);

            List<Turist> turist_fifo = new List<Turist>();
            List<Turist> turist_pq = new List<Turist>();

            foreach (Turist t in turistler)
            {
                if (t.Asansor_no == 0)
                    turist_fifo.Add(t);
                else if (t.Asansor_no == 1)
                    turist_pq.Add(t);
            }
     
            
            AsansorPQ<Turist> q1 = new AsansorPQ<Turist>();
            Queue<Turist> q0 = new Queue<Turist>();

            List<Turist> turistler4 = new List<Turist>();

            foreach (Turist t in turistler)
            {
                q0.Enqueue(t);
                q1.Enqueue(t, t.Kat_no);
                turistler4.Add(t);
                if (turistler4.Count == 4)
                    break;


            }
            
             List<Turist> SureHesapla(List<Turist> turistler2)
            {
                List<Turist> Turist_sureler = new List<Turist>();
                AsansorPQ<Turist> q11 = new AsansorPQ<Turist>();
                
                foreach (Turist t in turistler2)
                    q11.Enqueue(t, t.Kat_no);
                
                int toplam_sure = 0;
                int son_kat = 0;
                for(int i = 0; i < 4; i++)
                {
                    Turist t = q11.Peek();
                    toplam_sure += (t.Kat_no - son_kat) * 4 + 5 ;
                    if (t.Kat_no == son_kat)
                        toplam_sure -= 5;
                    
                    Turist t1 = q11.Dequeue();
                    son_kat = t1.Kat_no;
                    
                    t.SureFIFO = toplam_sure;
                    Turist_sureler.Add(t);
                }

                return Turist_sureler;
            }

            List<Turist> turist_sureler = SureHesapla(turistler4);

            
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(q1.Dequeue());
            }

          
            

            
            Console.ReadKey();

            

        }

    }
}
