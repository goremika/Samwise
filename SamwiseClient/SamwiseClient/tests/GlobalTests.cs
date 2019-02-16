using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamwiseClient.lib.measurements;
using SamwiseClient.lib.storages;
using SamwiseClient.lib.metrics;

namespace SamwiseClient.tests
{
    [TestClass]
    public class GlobalTests
    {
        [TestMethod]
        public void TestBasicMetricCreation()
        {
            IMetric me = new PerformaceCounterAbsolute("Memory", "Available MBytes");
            Measurement m = me.Measure();
            IStorage storage = new LocalCsv("local_storage.csv");
            //Assert.AreEqual("hello", m.Json());
            storage.Save(m);
        }
    }
}
