using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4
{
	public static class TaskUtils
	{
        public static Dictionary<string, int> FindStreetCounts(Agency agency, ref Dictionary<string, int> streetCounts) 
        {
            foreach (RealEstate estate in agency)
            {
                if (streetCounts.ContainsKey(estate.Street))
                {
                    streetCounts[estate.Street]++;
                }
                else
                {
                    streetCounts[estate.Street] = 1;
                }
            }
            return streetCounts;
        }





	}
}