using System.Collections.Generic;

namespace Proje2A1
{
    public class AsansorPQ<Turist>
    
    {

            List<Turist> turistler1 = new List<Turist>(); 
            List<int> numaralar;

            public AsansorPQ()
            {
                turistler1 = new List<Turist>();
                numaralar = new List<int>();
            }

            
            public int Count { get { return turistler1.Count; } }

            
            public int Enqueue(Turist turist, int priority) 
            {
                
                for (int i = 0; i < numaralar.Count; i++) 
                {
                    if (numaralar[i] >= priority)
                    {
                        turistler1.Insert(i, turist);
                        numaralar.Insert(i, priority);
                        return i;
                    }
                }
                
                turistler1.Add(turist);
                numaralar.Add(priority);
                return turistler1.Count - 1;
            }

            public Turist Dequeue()
            {
                Turist turist = turistler1[0];
                numaralar.RemoveAt(0);
                turistler1.RemoveAt(0);
                return turist;
            }

            public Turist Peek()
            {
                return turistler1[0];
            }

        }
    }

