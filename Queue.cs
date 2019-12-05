using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2A1
{
    public class Queue<Turist>
    {
        public List<Turist> turistler;

        public int Count { get { return turistler.Count; } }

        public Turist Dequeue()
        {
            Turist turist = turistler[0];
            turistler.RemoveAt(0);
            return turist;
        }

        public void Enqueue(Turist turist)
        {
            turistler.Add(turist);
        }

        public Turist Peek()
        {
            return turistler[0];
        }

        public void QueueYazdır()
        {
            foreach (Turist turist in turistler)
            {
                Console.WriteLine(turist);
            }

        }

       

    }
}
