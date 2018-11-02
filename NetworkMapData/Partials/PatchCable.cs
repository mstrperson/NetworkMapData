using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapData
{
    public partial class PatchCable
    {
        public void Connect(ref Port a, ref Port b)
        {
            this.PortA = a;
            this.PortB = b;
        }
    }
}
