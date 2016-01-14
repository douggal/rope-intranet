using System;
using System.Collections.Generic;
using System.Text;

namespace RopeIntranet
{
    class Program
    {
        /// <summary>
        /// A programming exercise.  January 2016
        /// In C# developed with Visual Studio Community Edition 2015
        /// and GitHub.
        /// 
        /// From Google Code Jam Round 1C 2010 - Rope Intranet.
        /// https://code.google.com/codejam/contest/619102/dashboard
        ///  
        /// Quoting from the website:
        /// 
        /// Problem
        /// A company is located in two very tall buildings. The company
        /// intranet connecting the buildings consists of many wires,
        /// each connecting a window on the first building to a window
        /// on the second building.
        /// 
        /// You are looking at those buildings from the side, so that
        /// one of the buildings is to the left and one is to the right.
        /// The windows on the left building are seen as points on its
        /// right wall, and the windows on the right building are seen
        /// as points on its left wall. Wires are straight segments
        /// connecting a window on the left building to a window on the
        /// right building.
        /// 
        /// You've noticed that no two wires share an endpoint (in other
        /// words, there's at most one wire going out of each window).
        /// However, from your viewpoint, some of the wires intersect
        /// midway. You've also noticed that exactly two wires meet at
        /// each intersection point.
        /// 
        /// On the above picture, the intersection points are the black
        /// circles, while the windows are the white circles.
        /// 
        /// How many intersection points do you see?
        /// 
        /// Input
        /// 
        /// The first line of the input gives the number of test cases,
        /// T. T test cases follow. Each case begins with a line
        /// containing an integer N, denoting the number of wires you
        /// see.
        /// 
        /// The next N lines each describe one wire with two integers Ai
        /// and Bi. These describe the windows that this wire connects:
        /// Ai is the height of the window on the left building, and Bi
        /// is the height of the window on the right building.
        /// 
        /// Output
        /// 
        /// For each test case, output one line containing "Case #x: y",
        /// where x is the case number (starting from 1) and y is the
        /// number of intersection points you see.
        /// 
        /// Limits
        /// 
        /// 1 ≤ T ≤ 15.
        /// 1 ≤ Ai ≤ 104.
        /// 1 ≤ Bi ≤ 104.
        /// Within each test case, all Ai are different.
        /// Within each test case, all Bi are different.
        /// No three wires intersect at the same point.
        /// 
        /// Small dataset
        /// 
        /// 1 ≤ N ≤ 2.
        /// 
        /// Large dataset
        /// 
        /// 1 ≤ N ≤ 1000.
        /// 
        /// Done quoting.
        /// 
        /// Write a program to read the input data and solve each case for number of
        /// intersections.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Rope Intranet");

            InputFile infile = new InputFile();

            Console.WriteLine("Reading input file....");
            infile.ReadInputFile();
            Console.WriteLine("Done reading input file.");
            //for (var line=0; line<=infile.FileContents.Count-1; line++)
            //{
            //    Console.WriteLine("Line {0}: {1}", line,infile.FileContents[line]);
            //}

            int nwires = 0;
            int ncases = int.Parse(infile.ReadLineOfInput());
            Console.WriteLine("Number of cases/samples:  {0}", ncases);

            for (int i = 1; i <= ncases; i++)
            {
                nwires = int.Parse(infile.ReadLineOfInput());
                Sample s = new Sample(i, nwires);
                for (int j = 0; j < nwires; j++)
                {
                    String thisLine = infile.ReadLineOfInput();
                    String[] endPoints = thisLine.Split(' ');
                    s.AddWire(int.Parse(endPoints[0]), int.Parse(endPoints[1]));
                }

                int ncrosses = 0;
                ncrosses = s.FindNbrCrosses();

                Console.WriteLine("Case #{0}: {1}", i, ncrosses);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
