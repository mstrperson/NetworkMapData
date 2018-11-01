using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapData
{
    public partial class Room
    {
        /// <summary>
        /// Readonly Accessor for ports in this room.
        /// This room's ports cannot be modified through this enumeration.
        /// To add a port to a room, it must be added to a PortGroup in the room.
        /// </summary>
        public List<Port> Ports
        {
            get
            {
                List<Port> ports = new List<Port>();
                foreach(PortGroup grp in this.PortGroups)
                {
                    ports.AddRange(grp.Ports);
                }

                return ports;
            }
        }
    }
}
