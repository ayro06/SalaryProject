using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyPayProject
{
    public class ResidentPayRecord : PayRecord
    {
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates)
        {
            
        }

        public override double Tax { get { return TaxCalculator.CalculateResidentialTax(Gross); } }

        public override string GetDetails()
        {
            string val = $"---------- EMPLOYEE: {Id} ----------\n";
            val += $"GROSS:    {Gross:c}\n";
            val += $"NET:      {Net:c}\n";
            val += $"TAX:      {Tax:c}\n";
            return val;
        }
    }
}
