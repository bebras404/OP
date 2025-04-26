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

        ListClass<double> Bonuses { get; }

        /// <summary>
        /// Constructor for object.
        /// </summary>
        /// <param name="id">ID of a person.</param>
        /// <param name="bonuses">Bonus linked list for storing bonus amounts.</param>
        public Input(int id, ListClass<double> bonuses)
        {
            this.Id = id;
            this.Bonuses = bonuses;
        }

        public void Start()
        {
            Bonuses.Start();
        }

        public bool Exists()
        {
            return Bonuses.Exists();
        }

        public void Next()
        {
            Bonuses.Next();
        }

        public double Get()
        {
            return Bonuses.Get();
        }

        public ListClass<double> GetBonuses()
        {
            return Bonuses;
        }

        public void Add(double value)
        {
            Bonuses.Add(value);
        }

    }
}