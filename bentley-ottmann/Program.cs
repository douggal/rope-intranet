// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
using bentley_ottmann;

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

// read number of cases, don't forget to convert String to Int
var nbrCases = int.Parse(input.Dequeue());

// Run():
// for each case
//    read number of wires
//    for each wire
//       read endpoints and add to a list of the wires
//    call the B-O algorithm passing in the list of wires
//    print number of crossings

// create and start a Stopwatch instance
// https://stackoverflow.com/questions/16376191/measuring-code-execution-time
Stopwatch stopwatch = Stopwatch.StartNew();

foreach (var c in Enumerable.Range(1,nbrCases))
{
    // read nbr wires
    var n = int.Parse(input.Dequeue());

    // read endpoints of each wire
    // parallel lists - e.g., A[0] to B[0] is one wire between bldgs
    // A = building on the left
    // B = building on the right
    var A = new List<int>();
    var B = new List<int>();
    foreach (var w in Enumerable.Range(1,n))
    {
        var line = input.Dequeue().Split(' ');
        A.Add(int.Parse(line[0].Trim()));
        B.Add(int.Parse(line[1].Trim()));
    }
    var bo = new BentleyOttmann(A,B);
    var x = bo.CountEm();

    Console.WriteLine($"Case {c,4} has {n} wires with {x} intersections.");
    Console.WriteLine("  A:" + String.Join(",", A));
    Console.WriteLine("  B:" + String.Join(",", B));
}

//BentleyOttmann.Run();
stopwatch.Stop();
Console.WriteLine("\nDone.");
Console.WriteLine("Time elapsed: {0:##.###}ms", stopwatch.ElapsedMilliseconds);

