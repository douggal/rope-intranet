using System;
using System.Collections.Generic;
using System.Text;

namespace RopeIntranet
{
    public class Sample
    {
        public int NumberWires { get; set; }
        public int CaseNumber { get; set; }

        public List<Wire> wiresArray;

        public Sample(int c, int n)
        {
            CaseNumber = c;
            NumberWires = n;
            wiresArray = new List<Wire>();
        }

        public void AddWire(int a, int b)
        {
            Wire w = new Wire(a, b);
            wiresArray.Add(w);
        }

        public int FindNbrCrosses()
        {
            int n = 0;

            // for each wire
            for (var i = 0; i < wiresArray.Count; i++)
            {
                for (var j = 0; j < wiresArray.Count; j++)
                {
                    if (i != j)
                    {
                        // the wires cross if:
                        // endpoint A of wire j is higher on the bldg than endpoint A of wire i
                        // and endpoint B of wire i higher on the bldg than endpoint B of wire j
                        if ((wiresArray[j].A > wiresArray[i].A) & (wiresArray[i].B > wiresArray[j].B))
                        {
                            // the wire/ropes intersect.
                            n += 1;
                        }
                    }
                }

            }

            return n;
        }
    }
}

