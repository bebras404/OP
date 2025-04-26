using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Class that handles all inputs and outputs.
    /// </summary>
    static class InOutUtils
    {
        /// <summary>
        /// Writes all calcualted data to file.
        /// </summary>
        /// <param name="fileName">Name of a file.</param>
        /// <param name="payouts">Linked list.</param>
        /// <param name="header">Header to write.</param>
        public static void WriteToFileCalculations(string fileName, ListClass<Payout> payouts, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 279));
                writer.WriteLine($"| {"Pavardė",20} | {"Vardas",15} | {"Tema1",-15} | {"Tema2",-15} |" +
                    $" {"Tema3",-15} | {"Tema4",-15} | {"Premija už tema1",-30} | {"Premija už tema2",-30} |" +
                    $" {"Premija už tema3",-30} | {"Premija už tema4",-30} | {"Suma",-30}");
                writer.WriteLine(new string('-', 279));
                for (payouts.Start(); payouts.Exists(); payouts.Next())
                {
                    string line = ($"| {payouts.Get().LastName,20} | {payouts.Get().Name,15} |");
                    for (payouts.Get().StartCoef(); payouts.Get().ExistsCoef(); payouts.Get().NextCoef())
                    {
                        line += ($" {payouts.Get().GetCoef().ToString(),-15} |");
                    }
                    for (payouts.Get().StartAmount(); payouts.Get().ExistsAmount(); payouts.Get().NextAmount())
                    {
                        line += ($" {payouts.Get().GetAmount().ToString(),-30} |");
                    }
                    line += ($" {payouts.Get().Sum,-30} |");
                    writer.WriteLine(line);
                }
                writer.WriteLine(new string('-', 279));
            }
        }
        /// <summary>
        /// Writes all input data to file.
        /// </summary>
        /// <param name="fileName">Name of a file.</param>
        /// <param name="inputList">Linked list.</param>
        /// <param name="header">Header to write.</param>
        public static void WriteToFileInput(string fileName, ListClass<Input> inputList, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 96));
                writer.WriteLine($"| {"Asmens kodas",20} | {"Tema1",-15} | {"Tema2",-15} | {"Tema3",-15} | {"Tema4",-15} | ");
                writer.WriteLine(new string('-', 96));
                for (inputList.Start(); inputList.Exists(); inputList.Next())
                {
                    string line = ($"| {inputList.Get().Id,20} |");
                    for (inputList.Get().StartCoef(); inputList.Get().ExistsCoef(); inputList.Get().NextCoef())
                    {
                        line += ($" {inputList.Get().GetCoef(),-15} |");
                    }
                    writer.WriteLine(line);
                }
                writer.WriteLine(new string('-', 96));
            }
        }
        /// <summary>
        /// Writes all worker data to file.
        /// </summary>
        /// <param name="fileName">Name of a file.</param>
        /// <param name="employeeList">Linked list.</param>
        /// <param name="header">Header to write.</param>
        public static void WriteToFileWorkers(string fileName, ListClass<Employee> employeeList, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 100));
                writer.WriteLine($"| {"Asmens kodas",20} | {"Pavardė",-15} | {"Vardas",-15} | {"Bankas",-15} | {"Banko sąskaita",-20} | ");
                writer.WriteLine(new string('-', 100));
                for (employeeList.Start(); employeeList.Exists(); employeeList.Next())
                {
                    writer.WriteLine(employeeList.Get().ToString());
                }
                writer.WriteLine(new string('-', 100));
            }
        }
        /// <summary>
        /// Writes all bonus data to file.
        /// </summary>
        /// <param name="fileName">Name of a file.</param>
        /// <param name="bonuses">Linked list.</param>
        /// <param name="header">Header to write.</param>
        public static void WriteToFileBonus(string fileName, ListClass<double> bonuses, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                int count = 1;
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 37));

                for (bonuses.Start(); bonuses.Exists(); bonuses.Next())
                {
                    double current = bonuses.Get();
                    writer.WriteLine($"| {"Tema" + count,-15} | {current.ToString(),-15} |");
                    count++;
                }
                writer.WriteLine(new string('-', 37));
                writer.WriteLine();
            }
        }



        /// <summary>
        /// Reads all workers.
        /// </summary>
        /// <param name="fileContetnt">File content.</param>
        /// <returns>Worker linked list.</returns>

        public static ListClass<Employee> ReadWorkers(Stream fileContetnt)
        {
            ListClass<Employee> list = new ListClass<Employee>();
            using (StreamReader reader = new StreamReader(fileContetnt))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Values = line.Split(';');
                    int ID = int.Parse(Values[0]);
                    string LastName = Values[1];
                    string Name = Values[2];
                    string BankName = Values[3];
                    string BankAccountNum = Values[4];
                    Employee w = new Employee(ID, LastName, Name, BankName, BankAccountNum);
                    list.Add(w);
                }
            }
            return list;
        }

        /// <summary>
        /// Reads all contributions.
        /// </summary>
        /// <param name="FileContent">Content of a file.</param>
        /// <returns>ContList linked list.</returns>
        public static ListClass<Input> ReadContributions(Stream FileContent)
        {
            ListClass<Input> list = new ListClass<Input>();
            using (StreamReader reader = new StreamReader(FileContent))
            {

                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] Values = line.Split(';');
                    int ID = int.Parse(Values[0]);
                    ListClass<double> contributionValuesList = new ListClass<double>();
                    foreach (var amount in Values.Skip(1))
                    {
                        double value = Double.Parse(amount);
                        contributionValuesList.Add(value);
                    }
                    Input c = new Input(ID, contributionValuesList);
                    list.Add(c);
                }
            }
            return list;
        }
        /// <summary>
        /// Reads all bonuses from first line of a file.
        /// </summary>
        /// <param name="FileContent">File content.</param>
        /// <returns>Linked list of all bonuses.</returns>

        public static ListClass<double> ReadBonusAmounts(Stream FileContent)
        {
            ListClass<double> list = new ListClass<double>();
            using (StreamReader reader = new StreamReader(FileContent))
            {
                string bonuses = reader.ReadLine();
                string[] Values = bonuses.Split(';');
                foreach (var value in Values)
                {
                    double bonus = double.Parse(value);
                    list.Add(bonus);
                }
            }
            return list;
        }
    }
}