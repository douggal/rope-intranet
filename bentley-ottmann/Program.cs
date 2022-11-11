// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Rope-Intranet Bentley-Ottmann");

// select input data set file
var df = "A-small-practice.txt";
var fn = Path.Combine(Directory.GetCurrentDirectory(), "data" ,df);

// Read in the input data line by line into a List<String>
Console.WriteLine($"Reading input data file");

// Use a Queue instead of a List collection to hold the input
// ref:  https://stackoverflow.com/questions/34399198/remove-and-return-first-item-of-list
var input = new Queue<String>();
try
{
    // Open the text file using a stream reader.
    using (var sr = new StreamReader($"{fn}", Encoding.UTF8))
    {
        String? line;
        while ((line = sr.ReadLine()) != null)
        {
            input.Enqueue(line);
        }
    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
    Console.WriteLine("Program exit.");
    Environment.Exit(-1);
}

// Quality control checks:
// Nbr cases, nbr lines read, first line of file, last line of the file
Console.WriteLine("---Input file specs---");
Console.WriteLine($"Number of lines read: {input.Count}");
Console.WriteLine($"First line of input: (also number of cases):");
Console.WriteLine(input.First());
Console.WriteLine($"Last line of input:");
Console.WriteLine(input.Last());
Console.WriteLine("---End input file specs---{0}{0}", Environment.NewLine);

// read number of cases
var nbrCases = input.Dequeue();

// Run():
// for each case
//    read number of wires
//    for each wire
//       read endpoints and add to a list of the wires
//    call the B-O algorithm passing in the list of wires
//    print number of crossings

//BentleyOttmann.Run();

Console.WriteLine("Done");

