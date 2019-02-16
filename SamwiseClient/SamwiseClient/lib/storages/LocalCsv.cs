using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamwiseClient.lib.measurements;
using System.IO;

namespace SamwiseClient.lib.storages
{
    class LocalCsv : IStorage
    {
        private string _filename;

        public LocalCsv(string filename)
        {
            _filename = filename;
        }

        public void Save(Measurement measurement)
        {
            using (StreamWriter sw = File.AppendText(_filename))
            {
                sw.WriteLine("\""+measurement.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\";\""+measurement.MetricName+"\";\""+measurement.Data.ToString()+"\";");
            }
        }
    }
}
