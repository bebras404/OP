using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace L4
{
    public static class InOutUtils
    {
        /// <summary>  
        /// Reads data about an agency from a file and creates an Agency object.  
        /// </summary>  
        /// <param name="fileName">The file to read data from.</param>  
        /// <returns>An Agency object with the data from the file.</returns>  
        public static Agency ReadAgency(string fileName)
        {
            Agency agency;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string name = reader.ReadLine();
                string address = reader.ReadLine();
                int phoneNumber;

                phoneNumber = int.Parse(reader.ReadLine());

                agency = new Agency(name, address, phoneNumber);

                string line;
                int lineNumber = 4;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    string[] values = line.Split(';');
                    try
                    {
                        string city = values[0];
                        string district = values[1];
                        string street = values[2];
                        int houseNumber = int.Parse(values[3]);
                        string type = values[4];
                        int buildYear = int.Parse(values[5]);
                        double area = double.Parse(values[6]);
                        int numberOfRooms = int.Parse(values[7]);
                        string diff = values[8];

                        RealEstate re;

                        if (int.TryParse(diff, out int floor))
                        {
                            re = new Flat(city, district, street, houseNumber, type, buildYear, area, numberOfRooms, floor);
                        }
                        else
                        {
                            re = new House(city, district, street, houseNumber, type, buildYear, area, numberOfRooms, diff);
                        }

                        agency.Add(re);
                    }
                    catch (Exception)
                    {
                        HttpContext.Current.Response.Write(
                         $"<script>alert('Klaida: [{fileName}, line {lineNumber}: {line.Replace("'", "\\'")}');</script>");
                        continue;
                    }
                }
            }

            return agency;
        }

        /// <summary>  
        /// Saves agency data to a CSV file.  
        /// </summary>  
        /// <param name="a">The agency to save.</param>  
        /// <param name="fileName">The file to save data to.</param>  
        /// <param name="header">The header text for the CSV file.</param>  
        public static void WriteToCSV(Agency a, string fileName, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine($"{"City"},{"District"},{"Street"}," +
                    $"{"House Number"},{"Type"},{"Build Year"},{"Area"}" +
                    $",{"Number of Rooms"},{"Heating Type"},{"Floor"}");
                foreach (RealEstate estate in a)
                {
                    writer.WriteLine(estate.ToString());
                }
            }
        }

        /// <summary>  
        /// Saves a dictionary of the most common streets to a file.  
        /// </summary>  
        /// <param name="fileName">The file to save data to.</param>  
        /// <param name="mostCommonStreets">The dictionary of streets and their counts.</param>  
        /// <param name="header">The header text for the file.</param>  
        public static void WriteToExternalDataDics(string fileName, Dictionary<string, int> mostCommonStreets, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 37));
                writer.WriteLine($"| {"Street",15} | {"Count",15} |");
                writer.WriteLine(new string('-', 37));
                foreach (var pair in mostCommonStreets)
                {
                    writer.WriteLine($"| {pair.Key,15} | {pair.Value,15} |");
                }
                writer.WriteLine(new string('-', 37));
            }
        }

        /// <summary>  
        /// Saves detailed agency data to a file.  
        /// </summary>  
        /// <param name="fileName">The file to save data to.</param>  
        /// <param name="agency">The agency to save.</param>  
        /// <param name="header">The header text for the file.</param>  
        public static void WriteToExternalData(string fileName, Agency agency, string header)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine($"{"Agency Name: "}{agency.Name}");
                writer.WriteLine($"{"Agency Address: "}{agency.Adress}");
                writer.WriteLine($"{"Agency Phone Number: "}{agency.PhoneNumber}");
                writer.WriteLine(new string('-', 191));
                writer.WriteLine($"| {"City",15} | {"District",15} | {"Street",15} |" +
                    $" {"House Number",-15} | {"Type",-15} | {"Build Year",15} |" +
                    $" {"Area",15} | {"Number of Rooms",-20} | {"Heating Type",20} | {"Floor",-15} |");
                writer.WriteLine(new string('-', 191));
                foreach (RealEstate estate in agency)
                {
                    writer.WriteLine($"| {estate.City,15} | {estate.District,15} |" +
                        $" {estate.Street,15} | {estate.HouseNumber,-15} | {estate.Type,15} |" +
                        $" {estate.BuildDate,-15} | {estate.Area,-15} | {estate.NumberOfRooms,-20} |" +
                        $" {(estate is House ? ((House)estate).HeatingType : "-"),20} |" +
                        $" {(estate is Flat ? ((Flat)estate).Floor.ToString() : "-"),-15} |");
                }
                writer.WriteLine(new string('-', 191));
            }
        }
    }


}

