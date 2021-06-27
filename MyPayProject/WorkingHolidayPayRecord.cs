using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyPayProject
{
    public class WorkingHolidayPayRecord: PayRecord
    {
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate;
        }

        public int Visa { get; private set; }
        public int YearToDate { get; private set; }
        public override double Tax { get { return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate); } }

        public override string GetDetails()
        {
            string val = $"---------- EMPLOYEE: {Id} ----------\n";
            val += $"GROSS:     {Gross:c}\n";
            val += $"NET:       {Net:c}\n";
            val += $"TAX:       {Tax:c}\n";
            val += $"VISA:      {Visa}\n";
            val += $"YTD:       {(Gross + YearToDate):c}\n";
            return val;
        }
    }
}
