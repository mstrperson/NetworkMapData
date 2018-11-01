using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapData
{
    public partial class Port
    {
        /// <summary>
        /// Ensures a reflexive relationship between connected ports a and b.
        /// If, either a or b is already connected to another port, this connection is severed reflexively as well.
        /// be sure to save changes after modifying ports!
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void ConnectPorts(ref Port a, ref Port b)
        {
            if (a.ConnectedPort != null)
            {
                a.ConnectedPort.ConnectedPort = null;
            }
            if (b.ConnectedPort != null)
            {
                b.ConnectedPort.ConnectedPort = null;
            }

            a.ConnectedPort = b;
            b.ConnectedPort = a;
        }
    }
}
