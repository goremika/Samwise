using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamwiseClient.lib.measurements;
using System.Diagnostics;



namespace SamwiseClient.lib.metrics
{
    class PerformaceCounterAbsolute : IMetric
    {
        private string _category;
        private string _name;
        private PerformanceCounter _counter;

        public PerformaceCounterAbsolute(string category, string name)
        {
            _category = category;
            _name = name;
            _counter = new PerformanceCounter(_category, _name);
        }

        private string MetricFullName()
        {
            return _category + " - " + _name;
        }

        public Measurement Measure()
        {
            return new Measurement(MetricFullName(), _counter.NextValue());
        }

    }
}

