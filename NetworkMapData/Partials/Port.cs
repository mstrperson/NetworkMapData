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

        public bool IsActive
        {
            get
            {
                if (this.IsSwitchPort) return true;
                
                foreach(Port port in this.ConnectedPorts)
                {
                    if (port.IsSwitchPort) return true;
                }

                return false;
            }
        }

        public String ActiveLabel => this.IsActive ? "Active" : "Inactive";

        public List<Port> ConnectedPorts
        {
            get
            {
                List<Port> ports = new List<Port>();

                if(PatchCableA.Count > 0)
                {
                    ports.Add(PatchCableA.First().PortB);
                }
                if(PatchCableB.Count > 0)
                {
                    ports.Add(PatchCableB.First().PortA);
                }

                List<Port> exc = new List<Port>() { this };
                exc.AddRange(ports);

                if(PatchCableA.Count > 0)
                {
                    ports.AddRange(PatchCableA.First().PortB.GetPortsExcluding(exc));
                }
                if(PatchCableB.Count > 0)
                {
                    ports.AddRange(PatchCableB.First().PortA.GetPortsExcluding(exc));
                }
                return ports;
            }
        }

        protected List<Port> GetPortsExcluding(List<Port> excludedPorts)
        {
            List<Port> ports = new List<Port>();

            if (PatchCableA.Count > 0 && !excludedPorts.Contains(PatchCableA.First().PortB))
            {
                ports.Add(PatchCableA.First().PortB);
            }
            if (PatchCableB.Count > 0 && !excludedPorts.Contains(PatchCableB.First().PortA))
            {
                ports.Add(PatchCableB.First().PortA);
            }

            if (PatchCableA.Count > 0 && !excludedPorts.Contains(PatchCableA.First().PortB))
            {
                ports.AddRange(PatchCableA.First().PortB.GetPortsExcluding(ports));
            }
            if (PatchCableB.Count > 0 && !excludedPorts.Contains(PatchCableB.First().PortA))
            {
                ports.AddRange(PatchCableB.First().PortA.GetPortsExcluding(ports));
            }

            return ports;
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
