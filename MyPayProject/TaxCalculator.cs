using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyPayProject
{
    public class TaxCalculator
    {
        public TaxCalculator()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gross"></param>
        /// <returns></returns>
        public static double CalculateResidentialTax(double gross)
        {
            if (gross <=72)
            {
                return (0.19 * gross) - 0.19;
            }
            else if (gross <= 361)
            {
                return (0.2342 * gross) - 3.213;
            }
            else if (gross <= 932)
            {
                return (0.3477 * gross) - 44.2476;
            }
            else if (gross <=1380)
            {
                return (0.345 * gross) - 41.7311;
            }
            else if (gross <=3111)
            {
                return (0.39 * gross) - 103.8657;
            }
            else
            {
                return (0.47 * gross) - 352.7888;
            }
        }

        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            if ((gross + yearToDate) <= 37000)
            {
                return gross * 0.15;
            }
            else if ((gross + yearToDate) <= 90000)
            {
                return gross * 0.32;
            }
            else if ((gross + yearToDate) <= 180000)
            {
                return gross * 0.37;
            }
            if ((gross + yearToDate) <= 9999999)
            {
                return gross * 0.45;
            }
            else
            {
                return 0;
            }
        }
    }
}
