using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace L4
{
    /// <summary>
    /// A Flat is a type of RealEstate.
    /// </summary>
    public class Flat : RealEstate
    {
        /// <summary>
        /// The floor number of the flat.
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Creates a new Flat with the given details.
        /// </summary>
        /// <param name="city">The city of the flat.</param>
        /// <param name="district">The district of the flat.</param>
        /// <param name="street">The street of the flat.</param>
        /// <param name="houseNumber">The house number of the flat.</param>
        /// <param name="type">The type of the flat.</param>
        /// <param name="buildDate">The year the flat was built.</param>
        /// <param name="area">The size of the flat in square meters.</param>
        /// <param name="numberOfRooms">The number of rooms in the flat.</param>
        /// <param name="Floor">The floor number of the flat.</param>
        public Flat(string city, string district, string street, int houseNumber, string type, int buildDate, double area, int numberOfRooms, int Floor) :
            base(city, district, street, houseNumber, type, buildDate, area, numberOfRooms)
        {
            this.Floor = Floor;
        }

        /// <summary>
        /// Checks if another object is the same as this Flat.
        /// </summary>
        /// <param name="other">The object to compare with.</param>
        /// <returns>True if they are the same, otherwise false.</returns>
        public override bool Equals(object other)
        {
            return this.Equals(other as Flat);
        }

        /// <summary>
        /// Checks if another Flat is the same as this Flat.
        /// </summary>
        /// <param name="flat">The Flat to compare with.</param>
        /// <returns>True if they are the same, otherwise false.</returns>
        public bool Equals(Flat flat)
        {
            if (flat == null)
            {
                return false;
            }
            return base.Equals(flat);
        }

        /// <summary>
        /// Compares this Flat with another Flat
        /// </summary>
        /// <param name="flat">The Flat to compare with.</param>
        /// <returns>
        /// A negative number if this Flat is smaller, 0 if they are the same, or a positive number if this Flat is larger.
        /// </returns>
        public int CompareTo(Flat flat)
        {
            if (this.Area.CompareTo(flat.Area) == 0)
            {
                return this.Floor.CompareTo(flat.Floor);
            }
            return this.Area.CompareTo(flat.Area);
        }

        /// <summary>
        /// Gets a unique number for this Flat.
        /// </summary>
        /// <returns>A unique number for this Flat.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Checks if the flat is large.
        /// </summary>
        /// <returns>True if the flat is large otherwise false</returns>
        public override bool IsLarge()
        {
            return this.Area > 90;
        }

        /// <summary>
        /// Gets a text description of the Flat
        /// </summary>
        /// <returns>A text description of the Flat.</returns>
        public override string ToString()
        {
            return base.ToString() + $",{"-"},{this.Floor}";
        }
    }
}