using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2A1
{
    public class AsansörFIFO : Queue<Turist>

    {
        private static double katÇıkışSüresi = 4;

        public AsansörFIFO()
        {
            turistler = new List<Turist>();
        }

        private AsansörPQ asansöreEkle(AsansörFIFO kişiler)
        {
            int kişiSayısı = kişiler.Count;

            if (kişiler.Count < 4)
            {
                AsansörPQ asansörGrubu = new AsansörPQ();

                for (int i = 0; i < kişiSayısı; i++)
                {
                    Turist turist = kişiler.Dequeue();
                    asansörGrubu.Enqueue(turist, turist.getKatNo);
                }
                return asansörGrubu;
            }
            else
            {
                AsansörPQ asansörGrubu = new AsansörPQ();
                for (int i = 0; i < 4; i++)
                {
                    Turist turist = kişiler.Dequeue();
                    asansörGrubu.Enqueue(turist, turist.getKatNo);
                }
                return asansörGrubu;
            }
        }

        private double süreHesapla(AsansörPQ asansörGrubu, bool rnd_kontrol)
        {
            double toplamSüre = 0;
            double öncekiSüre = 0;
            int j = 0;

            HashSet<int> katNo = new HashSet<int>();
            double süre = 0;
            int kişiSayısı = asansörGrubu.Count;

            for (int i = 0; i < kişiSayısı; i++)
            {
                
                Turist turist = asansörGrubu.Dequeue();

                if (katNo.Add(turist.getKatNo) == false)
                {

                    if (rnd_kontrol)
                    {
                        turist.setRandomSüre = öncekiSüre;
                    }
                    else
                    {
                        turist.setFIFOsüre = öncekiSüre;
                    }

                }
                else
                {
                    j++;
                    süre = ((turist.getKatNo) * katÇıkışSüresi + (j * 5));
                    if (rnd_kontrol)
                    {
                        turist.setRandomSüre = süre;
                    }
                    else
                    {
                        turist.setFIFOsüre = süre;
                    }
                    öncekiSüre = süre;
                }

                toplamSüre += süre;
            }
            return toplamSüre;
        }

        public double FIFOsüre(AsansörFIFO kişiler, bool rnd_kontrol)
        {
            AsansörPQ asansörGrubu = asansöreEkle(kişiler);
            return süreHesapla(asansörGrubu, rnd_kontrol);
        }
    }
}
