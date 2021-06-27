using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyPayProject
{
    public abstract class PayRecord
    {
        //Fields
        protected double[] _hours;
        protected double[] _rates;


        //Constructor
        public PayRecord(int id, double[] hours, double[] rates)
        {
            Id = id;
            _hours = hours;
            _rates = rates;
        }

        //Properties
        public int Id { get; private set; }
        public double Gross
        { get
            {
                return GetGross(_hours,_rates);

            }
        }
        public abstract double Tax { get; }
        public double Net { get { return Gross - Tax; } }

        public static double GetGross(double[] _hours, double[] _rates)
        {
            double gross = 0;

            for (int i = 0; i < _hours.Length; i++)
            {
                 gross += _hours[i] * _rates[i];
            }
            return gross;
        }

        public virtual string GetDetails()
        {
            return "";
        }
    }
}
