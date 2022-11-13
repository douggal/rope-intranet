using System;
namespace bentley_ottmann
{
	public class BentleyOttmann
	{
        public List<Point> A { get; set; }
        public List<Point> B { get; set; }

        SortedSet<Point> Q = new SortedSet<Point>();  // event points
        SortedSet<Point> U = new SortedSet<Point>();  // upper end of line seg points
        SortedSet<Point> L = new SortedSet<Point>();  // lower end of line seq points
        SortedSet<Point> C = new SortedSet<Point>();  // Contains


        public BentleyOttmann(List<int> a, List<int> b)
		{
            // The constructor takes two parallel lists, a and a.
            // The a and b are lists of end points (y-coord).
            // Turn the lone y-coord into Points by assuming bldg A
            // is a x-coord = 0 and bldg B is at x-coord 1.

            var AI = new List<Point>();
            var BI = new List<Point>();
            
            foreach (var ai in a) AI.Add(new Point(0, ai));
            foreach (var bi in b) BI.Add(new Point(1, bi));

            A = AI;
            B = BI;

            // We can leverage the simplifying limits - all of the points
            // start in bldg A and end in bldg B - there are no line
            // segments starting and/or ending inbetween in the general case
            // described in the video.  We also know no two line segments share
            // start or end point.

            // I turn the two lists of y coord endpoints into Point types so that I
            // can more easily use published algorithms.

            // Notes: Helpful video series by Phillip Kindermann:
            // https://www.youtube.com/watch?v=I9EsN2DTnN8

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
            // a SortedSet<T> implements a balance binary search tree

            // populate Q with all the endpoints
            for (int i = 0; i < A.Count; i++)
            {
                Q.Add(A[i]);
                if (A[i].y > B[i].y) U.Add(A[i]);
                else L.Add(A[i]);
            }
            for (int i = 0; i < B.Count; i++)
            {
                Q.Add(B[i]);
                if (B[i].y > A[i].y) U.Add(A[i]);
                else L.Add(B[i]);
            }

            // debug
            Console.WriteLine("Q: " + String.Join(",", Q));
            Console.WriteLine("U: " + String.Join(",", U));
            Console.WriteLine("L: " + String.Join(",", L));

            // T is the line segements currently intersecting the sweep line
            var T = new SortedSet<Tuple<Point, Point>>();

            // sentinals, two vertical lines at infinity
            T.Add(Tuple.Create(new Point(int.MaxValue, int.MaxValue), new Point(-int.MaxValue, -int.MaxValue)));
            T.Add(Tuple.Create(new Point(-int.MaxValue, int.MaxValue), new Point(-int.MaxValue, -int.MaxValue)));

            // Sweep down from highest point and count up any intersections observed
            while (Q.Count > 0)
            {
                // SortedSet<int> is in ascending order, so remove last item
                var p = Q.Last();
                //Console.WriteLine($"Item removed {p}");
                Q.Remove(p);

                // only want to compare segments currently intersected by sweep line
                handleEvent(p);
            }

            return count;
        }

        private int handleEvent(Point p)
        {

            var c = 0;



            //var max = A.Count-1;
            //// find any points in A less than p-1
            //for (int i = max; i >= 0; i--)
            //{
            //    if (A[i] < p)
            //    {
            //        // find any points in B that cross, count 'em
            //        for (int j = 0; j < max; j++)
            //        {
            //            if (B[j] > A[i] && A[i] > p)
            //            {
            //                c += 1;
            //            }
            //        }
            //    }
            //}

            return c;
        }

        private bool hasIntersection(Point A, Point B, Point C, Point D)
        {
            // https://stackoverflow.com/questions/3838329/how-can-i-check-if-two-segments-intersect
            return ccw(A, C, D) != ccw(B, C, D) && ccw(A, B, C) != ccw(A, B, D);
        }

        private bool ccw(Point A, Point B, Point C)
        {
            // https://bryceboe.com/2006/10/23/line-segment-intersection-algorithm/
            // ccw returns true if the 3 points are listed in counterclockwise order
            return (C.y - A.y) * (B.x - A.x) > (B.y - A.y) * (C.x - A.x);
        }
    }
}

