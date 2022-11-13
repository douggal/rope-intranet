using System;
namespace bentley_ottmann
{
	public class Point : IEquatable<Point>, IComparable<Point>
	{
        public int x { get; set; }
        public int y { get; set; }

        public Point(int xin, int yin)
        {
            x = xin;
            y = yin;
        }

        public bool Equals(Point? other)
        {
            if (x == other.x && y == other.y) return true;
            else return false;
        }

        public String ToString(Point? p)
        {
            return $"({p.x},{p.y})";
        }

        public int CompareTo(Point? p)
        {
            if (y == p.y) return 0;
            else if (y > p.y || (y == p.y && x < p.x)) return 1;
            else return -1;
        }
    }
}

