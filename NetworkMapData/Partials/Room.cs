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
                    return db.Rooms.Count() > 0 ? db.Rooms.OrderByDescending(p => p.Id).First().Id + 1 : 0;
                }
            }
        }

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

        /// <summary>
        /// Create a new PortGroup for this room with a collection of ports.
        /// </summary>
        /// <param name="dropName"></param>
        /// <param name="ports"></param>
        /// <returns></returns>
        public PortGroup CreateNetworkDrop(string dropName, ICollection<Port> ports = null)
        {
            PortGroup portGroup = new PortGroup()
            {
                Id = PortGroup.NextAvailableId,
                Name = dropName,
                Notes = ""
            };

            foreach(Port p in ports)
            {
                portGroup.Ports.Add(p);
            }

            this.PortGroups.Add(portGroup);

            return portGroup;
        }
    }
}
