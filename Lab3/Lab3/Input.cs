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

        public void StartCoef()
        {
            Coef.Start();
        }

        public bool ExistsCoef()
        {
            return Coef.Exists();
        }

        public void NextCoef()
        {
            Coef.Next();
        }

        public double GetCoef()
        {
            return Coef.Get();
        }

        public void AddCoef(double value)
        {
            Coef.Add(value);
        }

        public int CompareTo(Input other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(Input other)
        {
            return this.Id.Equals(other.Id);
        }

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