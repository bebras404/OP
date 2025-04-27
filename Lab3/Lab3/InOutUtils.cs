using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Class that handles all inputs and outputs.
    /// </summary>
    static class InOutUtils
    {
        public static void WriteToFile<T>(string fileName, IEnumerable<T> List, string Header, string TableHeader, int ws) where T : IEquatable<T>, IComparable<T>
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(Header);
                writer.WriteLine(new string('-', ws));
                writer.WriteLine(TableHeader);
                writer.WriteLine(new string('-', ws));
                foreach (T obj in List)
                {
                    writer.WriteLine($"| {obj.ToString(),-10} |");
                }
                writer.WriteLine(new string('-', ws));
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