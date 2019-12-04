using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2A1
{       
    public class Turist
        {
            private int katNo;
            private int numara;
            private String isim;

            private double FIFOsüre;
            private double PQsüre;
            private double randomSüre;
            private int randomNo; //0: FIFO 1: PQ 2: MERDİVEN

            public Turist(int katNo, int numara, String isim)
            {
                this.katNo = katNo;
                this.numara = numara;
                this.isim = isim;
            }

            public override string ToString()
            {
                return "Kat numarası: " + katNo + "\nNumara: " + numara + "\nİsim: " + isim
                    + "\nFIFO işlem süresi: " + FIFOsüre + "\nPQ işlem süresi: " + PQsüre + "\nRandom işlem süresi: " + randomSüre;
            }

            public int setKatNo
            {
                set { katNo = value; }
            }
            public int getKatNo
            {
                get { return katNo; }
            }

            public int setNumara
            {
                set { numara = value; }
            }
            public int getNumara
            {
                get { return numara; }
            }

            public String setİsim
            {
                set { isim = value; }
            }
            public String getİsim
            {
                get { return isim; }
            }

            public double setFIFOsüre
            {
                set { FIFOsüre = value; }
            }
            public double getFIFOsüre
            {
                get { return FIFOsüre; }
            }

            public double setPQsüre
            {
                set { PQsüre = value; }
            }
            public double getPQsüre
            {
                get { return PQsüre; }
            }

            public double setRandomSüre
            {
                set { randomSüre = value; }
            }
            public double getRandomSüre
            {
                get { return randomSüre; }
            }

            public int setRandomNo
            {
                set { randomNo = value; }
            }
            public int getRandomNo
            {
                get { return randomNo; }
            }

        }
    }

