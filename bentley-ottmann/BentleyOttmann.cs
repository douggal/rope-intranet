using System;
namespace bentley_ottmann
{
	public class BentleyOttmann
	{
        public List<int> A { get; set; }
        public List<int> B { get; set; }

        public BentleyOttmann(List<int> a, List<int> b)
		{
            A = a;
            B = b;

            // Helpful video series by Phillip Kindermann:
            // https://www.youtube.com/watch?v=I9EsN2DTnN8

            // We can leverage the simplifying limits - all of the points
            // start in bldg A and end in bldg B - there are no line
            // segments starting and/or ending inbetween in the general case
            // described in the video.  We also know no two line segments share
            // start or end point.  This means we can treat the points as if they
            // have only one coordinate, the y-axis value.

            // event (point) queue Q
            // p < q if y(p) > y(q) or (y(p) = y(q) and x(p) < x(q)
            // balanced binary search tree - red/black or AVL tree
            //  can find nextEvent(), del/insEvent()

            // https://stackoverflow.com/questions/3262947/is-there-a-built-in-binary-search-tree-in-net-4-0

            // sweep line status T
            // store segments intersected by l in left-to-right order
            // balanced binary search tree

        }

        public int CountEm()
        {
            var count = 0;

            // S the set of non-overlapping closed line segments
            // is just the pairs properties A[i], B[I] populated in constructor

            // Q = a priority queue, we know no two points share an endpoint
            var Q = new SortedSet<int>();
            foreach (var a in A) Q.Add(a);
            //Console.WriteLine(String.Join(",",Q));

            // Sweep down from highest point and count up any intersections observed
            while (Q.Count > 0)
            {
                // SortedSet<int> is in ascending order, so remove last item
                var p = Q.Last();
                //Console.WriteLine($"Item removed {p}");
                Q.Remove(p);

                // look at the line whose endpoint in A is p: does anything cross it?
                // that is, are there any endpoints where A[i] < p-1 and B[i] > p+1, or vice versa
                handleEvent(p);

                // Need: list of indexes of any points in A < p
                //  and whose corresponding B point is > B[i]

            }

            return count;
        }

        private int handleEvent(int p)
        {
            // are there any endpoints where A[i] < p-1 and B[i] > p+1?
            // are there any endpoints where A[i] > p+1 and B[i] < p-1?

            var c = 0;
            var max = A.Count-1;
            // find any points in A less than p-1
            for (int i = max; i >= 0; i--)
            {
                if (A[i] < p)
                {
                    // find any points in B that cross, count 'em
                    for (int j = 0; j < max; j++)
                    {
                        if (B[j] > A[i] && A[i] > p)
                        {
                            c += 1;
                        }
                    }
                }
            }

            return c;
        }
    }
}

