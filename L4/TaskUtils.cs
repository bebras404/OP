using System.Collections.Generic;

namespace L4
{
    public static class TaskUtils
    {
        /// <summary>
        /// Finds all large real estates from the given agencies.
        /// </summary>
        /// <param name="agencies">Array of agencies to search in.</param>
        /// <returns>Agency containing only large real estates.</returns>
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

        /// <summary>
        /// Combines all agencies into one.
        /// </summary>
        /// <param name="agencies">Array of agencies to combine.</param>
        /// <returns>A single agency containing all real estates.</returns>
        public static Agency FuseAgencies(Agency[] agencies)
        {
            Agency Fused = new Agency();
            foreach (Agency agency in agencies)
            {
                Fused += agency;
            }
            return Fused;
        }

        /// <summary>
        /// Finds real estates that appear in multiple agencies.
        /// </summary>
        /// <param name="fused">An agency containing all real estates.</param>
        /// <returns>Agency with real estates found in multiple agencies.</returns>
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

        /// <summary>
        /// Picks out real estates built in a specific year.
        /// </summary>
        /// <param name="agencies">Array of agencies to search in.</param>
        /// <param name="oldestValue">Year to filter by.</param>
        /// <returns>Agency with real estates built in the given year.</returns>
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

        /// <summary>
        /// Finds the minimum age of real estates across all agencies.
        /// </summary>
        /// <param name="agencies">Array of agencies to search in.</param>
        /// <returns>The minimum age of real estates.</returns>
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

        /// <summary>
        /// Finds the maximum count of real estates on a single street.
        /// </summary>
        /// <param name="streetCounts">Dictionary with street names and their counts.</param>
        /// <returns>The maximum count of real estates on a street.</returns>
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

        /// <summary>
        /// Creates a dictionary of street names and their real estate counts.
        /// </summary>
        /// <param name="agencies">Array of agencies to process.</param>
        /// <returns>Dictionary with street names and counts.</returns>
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

        /// <summary>
        /// Finds streets with the maximum number of real estates.
        /// </summary>
        /// <param name="values">Dictionary of street names and counts.</param>
        /// <param name="MaxValue">The maximum count to filter by.</param>
        /// <returns>Dictionary with streets having the maximum count.</returns>
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