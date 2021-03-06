﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMapData
{
    public partial class PatchCable
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
                    return db.PatchCables.Count() > 0 ? db.PatchCables.OrderByDescending(p => p.Id).First().Id + 1 : 0;
                }
            }
        }

        /// <summary>
        /// Connect two ports with this patch cable.
        /// </summary>
        /// <param name="a">PortA on this cable</param>
        /// <param name="b">PortB on this cable</param>
        public void Connect(ref Port a, ref Port b)
        {
            this.PortA = a;
            this.PortB = b;
        }
    }
}
