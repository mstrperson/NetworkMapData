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
        /// Get the next available ID from the database for this table.
        /// 
        /// ***Warning***
        /// Do not use this in a loop as it pulls from a new database context and will not 
        /// update until you save changes to the database in the context inwhich you are working.
        /// </summary>
        public static int NextAvailableId
        {
            get
            {
                using (NetworkDataEntities db = new NetworkDataEntities())
                {
                    return db.Ports.Count() > 0 ? db.Ports.OrderByDescending(p => p.Id).First().Id + 1 : 0;
                }
            }
        }


        /// <summary>
        /// Checks to see if this port is connected directly to another port with a patch cord.
        /// </summary>
        /// <param name="toPort">other port.</param>
        /// <returns></returns>
        public bool IsDirectlyConnected(Port toPort)
        {
            if (PatchCableA.Count > 0 && PatchCableA.Single().PortBId == toPort.Id)
                return true;

            if (PatchCableB.Count > 0 && PatchCableB.Single().PortAId == toPort.Id)
                return true;

            return false;
        }

        /// <summary>
        /// Is this port part of a Switch?
        /// (This is relevant because a switch port should only ever have a single patch cable attached).
        /// </summary>
        public bool IsSwitchPort
        {
            get
            {
                foreach(PortGroup portGroup in this.PortGroups)
                {
                    if (portGroup.Switches.Count > 0)
                        return true;
                }

                return false;
            }
        }
    }
}
