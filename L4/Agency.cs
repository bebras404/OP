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
    /// <summary>
    /// A real estate agency.
    /// </summary>
    public class Agency : IEnumerable<RealEstate>
    {
        public string Name { get; private set; }
        public string Adress { get; private set; }
        public int PhoneNumber { get; private set; }

        private List<RealEstate> realEstates;

        /// <summary>
        /// Creates an agency with name, address, and phone number.
        /// </summary>
        /// <param name="name">Agency name.</param>
        /// <param name="adress">Agency address.</param>
        /// <param name="phoneNumber">Agency phone number.</param>
        public Agency(string name, string adress, int phoneNumber)
        {
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.realEstates = new List<RealEstate>();
        }
        /// <summary>
        /// Creates an empty agency.
        /// </summary>
        public Agency()
        {
            this.realEstates = new List<RealEstate>();
        }
        /// <summary>
        /// Adds a real estate to the agency.
        /// </summary>
        /// <param name="re">Real estate to add.</param>
        public void Add(RealEstate re)
        {
            realEstates.Add(re);
        }
        /// <summary>
        /// Removes a real estate from the agency.
        /// </summary>
        /// <param name="re">Real estate to remove.</param>
        public void Remove(RealEstate re)
        {
            realEstates.Remove(re);
        }
        /// <summary>
        /// Gets a real estate by its position in the list.
        /// </summary>
        /// <param name="index">Position in the list.</param>
        /// <returns>The real estate at the position.</returns>
        public RealEstate Get(int index)
        {
            return realEstates[index];
        }
        /// <summary>
        /// Counts the real estates in the agency.
        /// </summary>
        /// <returns>Number of real estates.</returns>
        public int Count()
        {
            return realEstates.Count;
        }

        /// <summary>
        /// Checks if the agency has a specific real estate.
        /// </summary>
        /// <param name="estate">Real estate to check.</param>
        /// <returns>True if found, otherwise false.</returns>
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

        /// <summary>
        /// Finds the oldest real estate in the agency.
        /// </summary>
        /// <returns>Year of the oldest real estate.</returns>
        public int FindMinAge()
        {
            int minAge = 9999;
            foreach (RealEstate estate in realEstates)
            {
                if (estate.BuildDate < minAge)
                {
                    minAge = estate.BuildDate;
                }
            }
            return minAge;
        }
        /// <summary>
        /// Combines two agencies into one.
        /// </summary>
        /// <param name="a1">First agency.</param>
        /// <param name="a2">Second agency.</param>
        /// <returns>New agency with all real estates.</returns>
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
        /// <summary>
        /// Sorts the real estates in the agency.
        /// </summary>
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

        /// <summary>
        /// Allows looping through the real estates.
        /// </summary>
        /// <returns>Enumerator for real estates.</returns>
        public IEnumerator<RealEstate> GetEnumerator()
        {
            foreach (var realEstate in realEstates)
            {
                yield return realEstate;
            }
        }
        /// <summary>
        /// Allows looping through the real estates.
        /// </summary>
        /// <returns>Enumerator for real estates.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}