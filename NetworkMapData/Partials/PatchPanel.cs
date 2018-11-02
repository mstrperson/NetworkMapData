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
                    return db.PatchPanels.Count() > 0 ? db.PatchPanels.OrderByDescending(p => p.Id).First().Id + 1 : 0;
                }
            }
        }

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
