using System;
using System.Globalization;
using CsvHelper;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var testlist = new List<TestDataModel>();

            // for (int i = 0; i < 12; i++)
            // {
            //     testlist.Add(new TestDataModel() { val1 = i, val2 = "test" + i });
            // }
            // var writer = new StreamWriter("CSVs/test.csv");
            // var csvwriter = new CsvWriter(new StreamWriter("CSVs/test.csv"), CultureInfo.InvariantCulture);

            // csvwriter.WriteRecords(testlist);

            // csvwriter.Dispose();
            // writer.Dispose();

            var reader = new StreamReader("CSVs/test.csv");
            var csvreader = new CsvReader(new StreamReader("CSVs/test.csv"), CultureInfo.InvariantCulture);

            var output = csvreader.GetRecords<TestDataModel>().ToList();

            output.ForEach(x => Console.WriteLine($"{x.val1}\t{x.val2}"));
        }
    }
}