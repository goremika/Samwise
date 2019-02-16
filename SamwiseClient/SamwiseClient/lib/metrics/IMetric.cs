using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamwiseClient.lib.measurements;

namespace SamwiseClient.lib.metrics
{
    interface IMetric
    {
        Measurement Measure();
    }
}


