using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace SamwiseClient.lib.measurements
{
    class Measurement
    {
        private System.DateTime _timestamp;
        private Object _data;
        private string _metric_name;

        public System.DateTime Timestamp { get { return _timestamp; } }
        public Object Data { get { return _data; } }
        public string MetricName { get { return _metric_name;  } }

        public Measurement(string metric_name, Object data)
        {
            _timestamp = DateTime.Now;
            _metric_name = metric_name;
            _data = data;
        }

        public string Json()
        {
            return new JavaScriptSerializer().Serialize(new Dictionary<string, object> { {"timestamp", _timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff") },{"metric_name", _metric_name },{"data", _data } });
        }
    }
}
