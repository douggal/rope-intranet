using System;
using System.Collections.Generic;
using System.Text;

namespace rope_intranet
{
    public class Jan2016Pgm
    {
        /// <summary>
        /// See README.md file in this project for details.
        /// For each test case, output one line containing "Case #x: y",
        /// where x is the case number (starting from 1) and y is the
        /// number of intersection points you see.
        /// </summary>
        /// <param name="args"></param>
        public static void Run()
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

            // for each case in the file - I call it a sample - 
            // populate the case wire by wire read in from the data file,
            // compute number of crossings, then move on to next case.
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
