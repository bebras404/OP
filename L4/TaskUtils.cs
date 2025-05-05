using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace L4
{
	public static class TaskUtils
	{
        public static Agency FuseAgencies(Agency[] agencies) 
        {
            Agency Fused = new Agency();
            foreach (Agency agency in agencies) 
            {
                Fused += agency;
            }
            return Fused;

        }


        public static Agency FindInMultipleAgencies(Agency fused, int amountOfAgencies) 
        {
            for(int i = 0; i < fused.Count(); i++)
            {
                int count = 0;
                for (int j = 0; j < fused.Count(); j++) 
                {
                    if (fused.Get(i).Equals(fused.Get(j)))
                    {
                        count++;
                    }
                }
                if (count < amountOfAgencies)
                {
                    fused.Remove(fused.Get(i));
                }
               
            }
            fused.RemoveDublicates();
            return fused;
        }

        public static Agency PickOutOldest(Agency[] agencies, int oldestValue) 
        {
            Agency oldestRealEstates = new Agency();
            foreach (Agency a in agencies) 
            {
                foreach (RealEstate estate in a) 
                {
                    if (estate.BuildDate == oldestValue)
                    {
                        oldestRealEstates.Add(estate);
                    }
                }
            }
            return oldestRealEstates;
        }

        public static int MinAgeForAll(Agency[] agencies) 
        {
            int minAge = 9999;
            foreach (Agency agency in agencies)
            {
                if (minAge > agency.FindMinAge()) 
                {
                    minAge = agency.FindMinAge();
                }
            }
            return minAge;
        }

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

        public static Dictionary<string, int> PickOutObjectsByStreets(string street, Agency[] agencies) 
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (Agency agency in agencies) 
            {
                foreach (RealEstate estate in agency) 
                {
                    if (estate.Street == street)
                    {
                        if (result.ContainsKey(estate.Street)) 
                        {
                            result[estate.Street]++;
                        }
                        else
                        {
                            result.Add(estate.Street, 1);
                        }
                    }
                }
            }
            return result;
        }






    }
}