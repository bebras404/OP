using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Input object class.
    /// </summary>
    public class Input
    {
        public int Id { get; set; }
        private ListClass<double> Coef { get; }

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

    }
}