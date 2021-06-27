using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyPayProject
{
    public class CsvImporter
    {
        public static List<PayRecord> ImportPayRecords(string file)
        {
            string path = Path.GetFullPath($@"../../../Import/{file}.csv");
            var stream = new StreamReader(path);
            stream.ReadLine();

            var records = new List<PayRecord>();
            int empId = -1;
            
            var hours = new List<double>();
            var rates = new List<double>();
            var visa = 0;
            var ytd = 0;

            for (string line = stream.ReadLine(); line != null; line = stream.ReadLine())
            {
                string[] columns = line.Split(',');

                if (int.Parse(columns[0]) != empId && empId != -1)
                {
                    records.Add(createPayRecord(empId, hours.ToArray(), rates.ToArray(), visa,ytd));
                    hours.Clear();
                    rates.Clear();
                }

                empId = int.Parse(columns[0]);
                hours.Add(double.Parse(columns[1]));
                rates.Add(double.Parse(columns[2]));
                if (columns[3] == "")
                {
                    visa = 0;
                    ytd= 0;
                }
                else
                {
                    visa = int.Parse(columns[3]);
                    ytd = int.Parse(columns[4]);
                }

            }
            if (empId != -1)
            {
                records.Add(createPayRecord(empId, hours.ToArray(), rates.ToArray(), visa, ytd));
            }


            return records;
        }

        private static PayRecord createPayRecord(int empId, double[] hours, double[] rates, int visa, int yearToDate)
        {
            if (visa != 417 && visa != 462)
            {
                return new ResidentPayRecord(empId, hours, rates);
            }
            else
            {
                return new WorkingHolidayPayRecord(empId, hours, rates, visa, yearToDate);
            }
        }
    }
}
