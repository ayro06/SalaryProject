using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using System.Linq;

namespace MyPayProject
{
    public class PayRecordWriter
    {
        public PayRecordWriter()
        {
        }

        public static void Write(string file, List<PayRecord> records, bool writeToConsole)
        {

            using (var writer = new StreamWriter(file))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records.Select(r => new { r.Id, r.Gross, r.Net, r.Tax }));
            }
            
            if (writeToConsole)
            {
                foreach (var record in records)
                {
                    Console.WriteLine(record.GetDetails());
                }
                
            }
        }
    }
}
