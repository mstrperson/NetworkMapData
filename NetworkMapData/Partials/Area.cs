using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapData
{
    public partial class Area
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
                    return db.Areas.Count() > 0 ? db.Areas.OrderByDescending(p => p.Id).First().Id + 1 : 0;
                }
            }
        }
    }
}
