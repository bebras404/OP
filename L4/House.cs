using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4
{   
    /// <summary>
    /// Represents a house, which is a type of property.
    /// </summary>
    public class House : RealEstate
    {
        /// <summary>
        /// The heating system used in the house.
        /// </summary>
        public string HeatingType { get; set; }

        /// <summary>
        /// Creates a new house with the given details.
        /// </summary>
        /// <param name="city">The city where the house is located.</param>
        /// <param name="district">The district where the house is located.</param>
        /// <param name="street">The street where the house is located.</param>
        /// <param name="houseNumber">The house number.</param>
        /// <param name="type">The type of the house.</param>
        /// <param name="buildDate">The year the house was built.</param>
        /// <param name="area">The size of the house in square meters.</param>
        /// <param name="numberOfRooms">The number of rooms in the house.</param>
        /// <param name="HeatingType">The heating system used in the house.</param>
        public House(string city, string district, string street, int houseNumber, string type, int buildDate, double area, int numberOfRooms, string HeatingType) :
            base(city, district, street, houseNumber, type, buildDate, area, numberOfRooms)
        {
            this.HeatingType = HeatingType;
        }

        /// <summary>
        /// Checks if another object is the same as this house.
        /// </summary>
        /// <param name="other">The object to compare with.</param>
        /// <returns>True if they are the same, false otherwise.</returns>
        public override bool Equals(object other)
        {
            return this.Equals(other as House);
        }

        /// <summary>
        /// Checks if another house is the same as this one.
        /// </summary>
        /// <param name="house">The house to compare with.</param>
        /// <returns>True if they are the same, false otherwise.</returns>
        public bool Equals(House house)
        {
            if (house == null)
            {
                return false;
            }
            return base.Equals(house);
        }

        /// <summary>
        /// Compares this house to another house by size and heating system.
        /// </summary>
        /// <param name="house">The house to compare with.</param>
        /// <returns>A negative number if this house is smaller, positive if larger, or 0 if they are the same size.</returns>
        public int CompareTo(House house)
        {
            if (this.Area.CompareTo(house.Area) == 0)
            {
                return this.HeatingType.CompareTo(house.HeatingType);
            }
            return this.Area.CompareTo(house.Area);
        }

        /// <summary>
        /// Gets a unique code for this house.
        /// </summary>
        /// <returns>A hash code for the house.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Checks if the house is big (over 200 square meters).
        /// </summary>
        /// <returns>True if the house is big, false otherwise.</returns>
        public override bool IsLarge()
        {
            return this.Area > 200;
        }

        /// <summary>
        /// Gets a text description of the house.
        /// </summary>
        /// <returns>A string with details about the house.</returns>
        public override string ToString()
        {
            return base.ToString() + $",{this.HeatingType},{"-"}";
        }
    }
}