using System;

namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = CsvImporter.ImportPayRecords("employee-payroll-data");
            Console.Write("Please enter 1 if you want to print to the console: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            PayRecordWriter.Write($@"../../../Export/{DateTime.Now.Ticks}-records.csv", records, input == "1");
        }
    }
}
