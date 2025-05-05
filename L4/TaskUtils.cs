using System.Collections.Generic;

namespace L4
{
    public static class TaskUtils
    {
        public static Agency LargeObjs(Agency[] agencies)
        {
            Agency bigOnes = new Agency();
            foreach (Agency agency in agencies)
            {
                foreach (RealEstate estate in agency)
                {
                    if (estate.IsLarge())
                    {
                        bigOnes.Add(estate);
                    }
                }
            }
            return bigOnes;
        }

        public static Agency FuseAgencies(Agency[] agencies)
        {
            Agency Fused = new Agency();
            foreach (Agency agency in agencies)
            {
                Fused += agency;
            }
            return Fused;

        }


        public static Agency FindInMultipleAgencies(Agency fused)
        {
            Agency result = new Agency();

            for (int i = 0; i < fused.Count(); i++)
            {
                RealEstate current = fused.Get(i);
                int count = 0;

                for (int j = 0; j < fused.Count(); j++)
                {
                    if (current.Equals(fused.Get(j)))
                    {
                        count++;
                        if (count > 1) break;
                    }
                }

                if (count > 1 && !result.Contains(current))
                {
                    result.Add(current);
                }
            }

            return result;
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

        public static int FindMaxStreetCount(Dictionary<string, int> streetCounts)
        {
            int max = 0;
            foreach (var pair in streetCounts)
            {
                if (pair.Value > max)
                {
                    max = pair.Value;
                }
            }
            return max;
        }


        public static Dictionary<string, int> PutToDicti(Agency[] agencies)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (Agency agency in agencies)
            {
                foreach (RealEstate estate in agency)
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
            return result;
        }

        public static Dictionary<string, int> PickOutCommonStreets(Dictionary<string, int> values, int MaxValue)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var pair in values)
            {
                if (pair.Value == MaxValue)
                {
                    result.Add(pair.Key, pair.Value);
                }
            }
            return result;
        }







    }
}