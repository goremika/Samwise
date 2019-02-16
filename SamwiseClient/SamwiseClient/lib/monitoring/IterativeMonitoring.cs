using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamwiseClient.lib.metrics;
using SamwiseClient.lib.storages;
using SamwiseClient.lib.measurements;
using System.Timers;

namespace SamwiseClient.lib.monitoring
{
    class IterativeMonitoring : IMonitoring
    {

        private int _interval;
        private IMetric[] _metrics;
        private IStorage[] _storages;
        private System.Timers.Timer _timer;

        public IterativeMonitoring(int interval, IMetric[] metrics, IStorage[] storages)
        {
            _interval = interval;
            _metrics = metrics;
            _storages = storages;
        }

        public void Update()
        {
            foreach (IMetric metric in _metrics)
            {
                Measurement measurement = metric.Measure();
                foreach (IStorage storage in _storages)
                {
                    storage.Save(measurement);
                }
            }
        }

        private  void OnTimer(Object source, ElapsedEventArgs e)
        {
            Update();
        }

        public void Start()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimer;
            _timer.AutoReset = true;
            _timer.Enabled = true;

        }
    }
}
