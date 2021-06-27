using System;
using System.Collections.Generic;
using System.IO;
using MyPayProject;
using NUnit.Framework;

namespace test
{
    public class Tests
    {
        private List<PayRecord> _records;
        private double[] grossArray = { 652, 418, 2202, 1104, 1797.45 };
        private double[] taxArray = { 182.45, 133.76, 754.91, 165.60, 597.14 };
        private double[] netArray = { 469.55, 284.24, 1447.09, 938.40, 1200.31 };


        [SetUp]
        public void Setup()
        {
            _records = CsvImporter.ImportPayRecords("employee-payroll-data-test");
        }

        [Test]
        public void TestImport()
        {
            Assert.IsNotNull(_records);
            Assert.IsNotEmpty(_records);
            Assert.AreEqual(5, _records.Count);
        }

        [Test]
        public void TestGross()
        {
            Assert.IsNotNull(grossArray);
            Assert.IsNotEmpty(grossArray);
            for (int i = 0; i < grossArray.Length; i++)
            {
                Assert.AreEqual(grossArray[i], Math.Round(_records[i].Gross, 2));
            }
        }

        [Test]
        public void TestTax()
        {
            Assert.IsNotNull(taxArray);
            Assert.IsNotEmpty(taxArray);
            for (int i = 0; i < taxArray.Length; i++)
            {
                Assert.AreEqual(taxArray[i], Math.Round(_records[i].Tax, 2));
            }
        }

        [Test]
        public void TestNet()
        {
            Assert.IsNotNull(netArray);
            Assert.IsNotEmpty(netArray);
            for (int i = 0; i < netArray.Length; i++)
            {
                Assert.AreEqual(netArray[i], Math.Round(_records[i].Net, 2));
            }
        }

        [Test]
        public void TestExport()
        {
            string file = $"{DateTime.Now.Ticks}-records";
            PayRecordWriter.Write($@"../../../Export/{file}.csv", _records, writeToConsole: false);
            bool exists = File.Exists(Path.GetFullPath($@"../../../Export/{file}.csv"));
            Assert.IsTrue(exists);
        }
    }
}