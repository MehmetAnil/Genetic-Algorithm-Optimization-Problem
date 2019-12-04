using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

namespace Proje2A1
{
    public class AsansörPQ : Queue<Turist>
    {
        private static double katÇıkışSüresi = 1.66;

        public AsansörPQ()
        {
            turistler = new List<Turist>();
        }

        public int Enqueue(Turist turist, int priority)
        {
            for (int i = 0; i < turistler.Count; i++)
            {
                if (turistler[i].getKatNo > priority)
                {
                    turistler.Insert(i, turist);
                    return 0;
                }
            }
            turistler.Add(turist);
            return 0;
        }

        private Turist[] asansöreEkle(AsansörPQ kişiler)
        {
            int kişiSayısı = kişiler.Count;

            if (kişiSayısı < 4)
            {
                Turist[] asansörGrubu = new Turist[kişiSayısı];

                for (int i = 0; i < kişiSayısı; i++)
                {
                    Turist turist = kişiler.Dequeue();
                    asansörGrubu[i] = turist;
                }
                return asansörGrubu;
            }
            else
            {
                Turist[] asansörGrubu = new Turist[4];
                for (int i = 0; i < 4; i++)
                {
                    asansörGrubu[i] = kişiler.Dequeue();
                }
                return asansörGrubu;
            }
        }

        private double süreHesapla(Turist[] asansörGrubu, bool rnd_kontrol,double toplamSüreGrup)
        {
            double toplamSüre = toplamSüreGrup;
            int öncekiKat = 0;
            HashSet<int> katNo = new HashSet<int>();
            double süre = 0;
            for (int i = 0; i < asansörGrubu.Length; i++)
            {
                
            if (katNo.Add(asansörGrubu[i].getKatNo) == false)
                {
                    if (rnd_kontrol)
                    {
                        asansörGrubu[i].setRandomSüre = asansörGrubu[i - 1].getRandomSüre;
                    }
                    else
                    {
                        asansörGrubu[i].setPQsüre = asansörGrubu[i - 1].getPQsüre;
                    }
                    toplamSüre += süre;
                }
                else
                {
                    
                    süre = ((asansörGrubu[i].getKatNo-öncekiKat) * katÇıkışSüresi +  5);
                    toplamSüre += süre;
                    if (rnd_kontrol)
                    {
                        asansörGrubu[i].setRandomSüre = toplamSüre;
                    }
                    else
                    {
                        asansörGrubu[i].setPQsüre = toplamSüre;
                    }
                }
                toplamSüre += süre;
                öncekiKat = asansörGrubu[i].getKatNo;
            }
            toplamSüre += katNo.Max() * katÇıkışSüresi;
            return toplamSüre;
        }

        public double PQsüre(AsansörPQ kişiler, bool rnd_kontrol,double toplamSüreGrup)
        {
            Turist[] asansörGrubu = asansöreEkle(kişiler);
            return süreHesapla(asansörGrubu, rnd_kontrol,toplamSüreGrup);
        }


    }

}

