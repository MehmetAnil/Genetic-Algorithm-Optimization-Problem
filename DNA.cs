using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2A1
{
    class DNA 
    {
        private double süre;
        private int[] numaralar;

        public DNA(){ }
        public DNA(double süre, int[] numaralar)
        {
            this.süre = süre;
            this.numaralar = numaralar;
        }

        

        public double getSüre
        {
            get { return süre; }
        }
        public double setSüre
        {
            set { süre = value; }
        }
        public int[] getNumaralar
        {
            get { return numaralar; }
        }
        public int[] setNumaralar
        {
            set { numaralar = value; }
        }
        private class sortSüreAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                DNA c1 = (DNA)a;
                DNA c2 = (DNA)b;
                if (c1.getSüre > c2.getSüre)
                    return 1;
                if (c1.getSüre < c2.getSüre)
                    return -1;
                else
                    return 0;
            }
        }
        public static IComparer sortSüreAscending()
        {
            return (IComparer)new sortSüreAscendingHelper();
        }

        
        //ArtanSort
        //AzalanSort

    }
}
