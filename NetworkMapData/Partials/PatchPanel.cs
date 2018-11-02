using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapData
{
    public partial class PatchPanel
    {
        /// <summary>
        /// Creates a "module" of ports on this panel.  Be sure to save the database context after use.
        /// </summary>
        /// <param name="portCount">Number of ports on this module</param>
        /// <param name="moduleName">Name of this module</param>
        /// <param name="portPrefix">Prefix to add to port names on this module</param>
        /// <param name="type">Type of ports... probably Ethernet...</param>
        /// <returns></returns>
        public PortGroup CreateModule(int portCount, string moduleName, string portPrefix)
        {
            PortGroup pg = new PortGroup()
            {
                Name = moduleName,
                Notes = ""
            };

            for (int i = 0; i < portCount; i++)
            {
                Port port = new Port()
                {
                    Name = String.Format("{0}{1}", portPrefix, i + 1),
                    Notes = ""
                };

                pg.Ports.Add(port);
            }

            this.PortGroups.Add(pg);

            return pg;
        }
    }
}
