using System;
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