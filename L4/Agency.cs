using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Xml;

namespace L4
{
	public class Agency : IEnumerable<RealEstate>
    {        	
		public string Name { get; private set; }
		public string Adress { get; private set; }
		public int PhoneNumber { get; private set; }

		private List<RealEstate> realEstates;

		public Agency(string name, string adress, int phoneNumber) 
		{
			this.Name = name;
			this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.realEstates = new List<RealEstate>();
        }

        public Agency() 
        {
            this.realEstates = new List<RealEstate>();
        }

        public void Add(RealEstate re) 
		{
            realEstates.Add(re);		
        }

		public void Remove(RealEstate re) 
		{
			realEstates.Remove(re);
		}

        public RealEstate Get(int index)
        {
            return realEstates[index];
        }

        public int Count() 
		{
            return realEstates.Count;
        }

        public void RemoveDublicates() 
        {
            for (int i = 0; i < realEstates.Count; i++)
            {
                for (int j = 0; j < realEstates.Count; j++)
                {
                    if (realEstates[i].Equals(realEstates[j]))
                    {
                        realEstates.RemoveAt(j);
                    }
                }
            }

        }

        public bool Contains(RealEstate estate) 
        {
            foreach (RealEstate curr in realEstates) 
            {
                if (curr.Equals(estate))
                {
                    return true;
                }
            }
            return false;
        }

        public int CountStreets(string street) 
        {
            int count = 0;
            foreach (var realEstate in realEstates)
            {
                if (realEstate.Street == street)
                {
                    count++;
                }
            }
            return count;
        }

        public int FindMinAge() 
        {
            int minAge = 9999;
            foreach(RealEstate estate in realEstates)
            {
                if (estate.BuildDate < minAge) 
                {
                    minAge = estate.BuildDate;
                }
            }
            return minAge;
        }

        public static Agency operator +(Agency a1, Agency a2)
        {
            Agency newAgency = new Agency();
            foreach (RealEstate estate in a1.realEstates)
            {
                newAgency.Add(estate);
            }
            foreach (RealEstate estate in a2.realEstates)
            {
                newAgency.Add(estate);
            }
            return newAgency;
        }

        public void BubbleSort()
        {
            int n = realEstates.Count();
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (realEstates[i].CompareTo(realEstates[j]) > 0)
                    {
                        RealEstate temp = realEstates[j];
                        realEstates[j] = realEstates[j + 1];
                        realEstates[j + 1] = temp;

                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }


        public IEnumerator<RealEstate> GetEnumerator()
        {
            foreach (var realEstate in realEstates)
            {
                yield return realEstate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}