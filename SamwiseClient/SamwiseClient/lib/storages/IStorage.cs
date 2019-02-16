using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamwiseClient.lib.measurements;

namespace SamwiseClient.lib.storages
{
    interface IStorage
    {
        void Save(Measurement measurement);
    }
}
