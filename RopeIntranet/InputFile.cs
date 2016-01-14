using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RopeIntranet
{
    public class InputFile
    {
        public String FileName { get; set; }
        public List<String> FileContents { get; set; }
        public int currLine { get; set; }

        public InputFile()
        {
            FileName = "A-small-practice.txt";
            //FileName = "A-large-practice.txt";
            FileContents = new List<String>();
            currLine = 0;
        }

        internal void ReadInputFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    int i = 0;
                    String line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        FileContents.Add(line);
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public String ReadLineOfInput()
        {
            string s = FileContents[currLine];
            currLine += 1;
            return s;
        }

    }
}
