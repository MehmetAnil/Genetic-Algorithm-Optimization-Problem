using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2A1
{
    class Turist
    {
        private String ad;
        private int numara;
        private int kat_no;
        
        private int asansor_no;
        
        private int sureFIFO;
        private int surePQ;

        public Turist(string ad, int numara, int kat_no)
        {
            this.ad = ad;
            this.numara = numara;
            this.kat_no = kat_no;
        }
        public Turist(string ad, int numara, int kat_no, int asansor_no,int sureFIFO)
        {
            this.ad = ad;
            this.numara = numara;
            this.kat_no = kat_no;
            this.asansor_no = asansor_no;
            this.sureFIFO = sureFIFO;
        }

        public String Ad
        {
            get { return ad; }
            set { ad = value; }
        }
        public int Numara 
        {
            get { return numara; }
            set { numara = value; }
        }
        public int Kat_no
        {
            get { return kat_no; }
            set { kat_no = value; }
        }
        public int Asansor_no
        {
            get { return asansor_no; }
            set { asansor_no = value; }
        }
        public int SureFIFO
        {
            get { return sureFIFO; }
            set { sureFIFO = value; }
        }
        public int SurePQ
        {
            get { return surePQ; }
            set { surePQ = value; }
        }

        public override string ToString()
        {
            return "Ad: "+Ad+"\n"+"Numara: "+Numara+"\n"+"Kat Numarası: "+Kat_no+"\n"+"Asansör Numarası: "+Asansor_no+"\n"+SureFIFO+"\n"+SurePQ;
        }

        


    }
}
