using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Input object class.
    /// </summary>
    public class Input : IComparable<Input>, IEquatable<Input>
    {
        public int Id { get; set; }
        private ListClass<double> Coef;

        /// <summary>
        /// Constructor for object.
        /// </summary>
        /// <param name="id">ID of a person.</param>
        /// <param name="bonuses">Bonus linked list for storing bonus amounts.</param>
        public Input(int id, ListClass<double> bonuses)
        {
            this.Id = id;
            this.Coef = bonuses;
        }

        /// <summary>
        /// Starts the linked list for coeficients.
        /// </summary>

        public void StartCoef()
        {
            Coef.Start();
        }

        /// <summary>
        /// Checks if the linked list for coeficients exists.
        /// </summary>
        /// <returns>True or false depening on existance of a value.</returns>

        public bool ExistsCoef()
        {
            return Coef.Exists();
        }

        /// <summary>
        /// Moves to the next coeficient in the linked list.
        /// </summary>

        public void NextCoef()
        {
            Coef.Next();
        }

        /// <summary>
        /// Gets the current coeficient from the linked list.
        /// </summary>
        /// <returns>Gets node data.</returns>

        public double GetCoef()
        {
            return Coef.Get();
        }

        /// <summary>
        /// Adds a coeficient to the linked list.
        /// </summary>
        /// <param name="value">Value to add.</param>

        public void AddCoef(double value)
        {
            Coef.Add(value);
        }

        /// <summary>
        /// Compares two Input objects by Id.
        /// </summary>
        /// <param name="other">Other Input object.</param>
        /// <returns></returns>

        public int CompareTo(Input other)
        {
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// Compares two Input objects by Id.
        /// </summary>
        /// <param name="other">Other Input object.</param>
        /// <returns>True or false depending on values.</returns>
        public bool Equals(Input other)
        {
            return this.Id.Equals(other.Id);
        }

        /// <summary>
        /// ToString override for formatting.
        /// </summary>
        /// <returns>Foramted string</returns>

        public override string ToString()
        {
            Coef.Start();
            string firstCoef = Coef.Get().ToString();
            Coef.Next();
            string secondCoef = Coef.Get().ToString();
            Coef.Next();
            string thirdCoef = Coef.Get().ToString();
            Coef.Next();
            string fourthCoef = Coef.Get().ToString();

            return string.Format($"{this.Id,20} | {firstCoef,-15} | {secondCoef,-15} | {thirdCoef,-15} | {fourthCoef,-15} ");
        }
    }
}