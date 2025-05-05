using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4
{
	public static class TaskUtils
	{
        public static string FindMaxStreet(Agency[] agencies)
        {
            int maxCount = 0;
            string mostCommonStreet = "";

            foreach (Agency agency in agencies)
            {
                foreach (RealEstate estate in agency)
                {
                    string street = estate.Street;
                    int count = agency.CountStreets(street);

                    if (count > maxCount)
                    {
                        maxCount = count;
                        mostCommonStreet = street;
                    }
                }
            }
            return mostCommonStreet;
        }

        public static List<RealEstate> PickOutObjectsByStreets(string street, Agency[] agencies) 
        {
            List<RealEstate> result = new List<RealEstate>();
            foreach (Agency agency in agencies) 
            {
                foreach (RealEstate estate in agency) 
                {
                    if (estate.Street == street)
                    {
                        result.Add(estate);
                    }
                }
            }
            return result;
        }






    }
}