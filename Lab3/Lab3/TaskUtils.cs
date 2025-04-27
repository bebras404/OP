using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lab3
{
    public static class TaskUtils
    {
        /// <summary>
        /// Creates a list of new payout objects.
        /// </summary>
        /// <param name="inputs">Input coeficients.</param>
        /// <param name="employees">Employees linked list.</param>
        /// <returns>Linked list of payout objects.</returns>
		public static ListClass<Payout> AddToList(ListClass<Input> inputs, ListClass<Employee> employees) 
        {
            ListClass<Payout> payoutList = new ListClass<Payout>();
            for (employees.Start(); employees.Exists(); employees.Next())
            {
                Employee employee = employees.Get();
                for (inputs.Start(); inputs.Exists(); inputs.Next())
                {
                    Input input = inputs.Get();
                    if (input.Id == employee.Id)
                    {
                        Payout p = new Payout(employee.LastName, employee.Name);
                        for (input.StartCoef(); input.ExistsCoef(); input.NextCoef())
                        {
                            p.AddCoef(input.GetCoef());
                        }
                        if (!payoutList.Contains(p))
                        {
                            payoutList.Add(p);
                        }
                    }
                }

            }
            return payoutList;
        }

        /// <summary>
        /// Calculates bonus for each worker and each theme.
        /// </summary>
        /// <param name="inputs">Input coeficients.</param>
        /// <param name="employees">Employees linked list.</param>
        /// <param name="bonuses">Bonus linked list.</param>
        /// <returns>Linked list with payout objects.</returns>
        public static ListClass<Payout> CalculateBonus(ListClass<Payout> payouts, ListClass<double> bonuses, ListClass<Input> inputs)
        {
            payouts.Start();
            while (payouts.Exists())
            {
                Payout payout = payouts.Get(); 
                bonuses.Start();
                payout.StartCoef();
                int themeNumber = 0;

                while (bonuses.Exists())
                {
                    double totalCoef = AllCoef(inputs, themeNumber);
                    double bonusAmount = 0;

                    if (totalCoef > 0)
                    {
                        bonusAmount = (payout.GetCoef() / totalCoef) * bonuses.Get();
                    }

                    payout.AddAmount(bonusAmount);
                    bonuses.Next();
                    payout.NextCoef();
                    themeNumber++;
                }

                
                payouts.Next();
            }


            return payouts;
        }

        /// <summary>
        /// Calculates sum of coeficiens for each theme.
        /// </summary>
        /// <param name="inputs">Input coeficients.</param>
        /// <param name="themeNumber">Theme number.</param>
        /// <returns></returns>
        private static double AllCoef(ListClass<Input> inputs, int themeNumber)
        {
            double coefs = 0;

            for (inputs.Start(); inputs.Exists(); inputs.Next())
            {
                var bonusList = inputs.Get();
                bonusList.StartCoef();
                for (int i = 0; i < themeNumber; i++)
                {
                    if (!bonusList.ExistsCoef()) break;
                    bonusList.NextCoef();
                }

                if (bonusList.ExistsCoef())
                {
                    coefs += bonusList.GetCoef();
                }
            }

            return coefs;
        }
        /// <summary>
        /// Picks out objects that have sum smaller than average sum.
        /// </summary>
        /// <param name="payouts">Payout linked list.</param>
        /// <returns>Payout linked list with objects that have smaller sums than average.</returns>
        public static ListClass<Payout> LessThanAvarage(ListClass<Payout> payouts, double avg)
        {
            ListClass<Payout> lessthanaverage = new ListClass<Payout>();
            for (payouts.Start(); payouts.Exists(); payouts.Next())
            {
                Payout p = payouts.Get();
                if (p.Sum < avg)
                {
                    lessthanaverage.Add(p);
                }
            }
            return lessthanaverage;
        }

        /// <summary>
        /// Calculates average of a bonus.
        /// </summary>
        /// <param name="payouts">Whole payout linked list.</param>
        /// <returns>Avergae of bonus sums.</returns>
        public static double CalculateAveragePayout(ListClass<Payout> payouts)
        {
            double sum = 0;
            int count = 0;
            for (payouts.Start(); payouts.Exists(); payouts.Next())
            {
                Payout p = payouts.Get();
                sum += p.Sum;
                count++;
            }
            return sum / count;
        }

        public static ListClass<Payout> FilterByTheme(string Theme, ListClass<Payout> payouts)
        {
            ListClass<Payout> filtered = new ListClass<Payout>();


            string[] values = Theme.Split(' ');
            int value = int.Parse(values[1]) - 1;

            for (payouts.Start(); payouts.Exists(); payouts.Next())
            {
                Payout p = new Payout(payouts.Get().LastName, payouts.Get().Name);
                payouts.Get().StartAmount();
                for (int i = 0; i < value; i++)
                {
                    payouts.Get().NextAmount();
                }
                p.AddAmount(payouts.Get().GetAmount());
                p.Sum = payouts.Get().Sum;
                for (payouts.Get().StartCoef(); payouts.Get().ExistsCoef(); payouts.Get().NextCoef()) 
                {
                    p.AddCoef(payouts.Get().GetCoef());
                }
                filtered.Add(p);
            }
            return filtered;
        }





    }
}