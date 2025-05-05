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
                         $"<script>alert('[BLOGA EILUTĖ] {fileName}, eilutė {lineNumber}: {line.Replace("'", "\\'")}');</script>");
                        continue;
                    }
                }
            }

            return agency;
        }



        public static void WriteToCSV(Agency a, string fileName, string header)
        {

            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine($"{"Miestas"},{"Rajonas"},{"Gatvė"}," +
                    $"{"Namo numeris"},{"Tipas"},{"Pastatymo metai"},{"Plotas"}" +
                    $",{"Kambarių skaičius"},{"Šildymo tipas"},{"Aukštas"}");
                foreach (RealEstate estate in a)
                {
                    writer.WriteLine(estate.ToString());
                }
            }


        }

        public static void WriteToExternalDataDics(string fileName, Dictionary<string, int> mostCommonStreets, string header)
        {

            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine(new string('-', 37));
                writer.WriteLine($"| {"Gatvė",15} | {"Kiekis",15} |");
                writer.WriteLine(new string('-', 37));
                foreach (var pair in mostCommonStreets)
                {
                    writer.WriteLine($"| {pair.Key,15} | {pair.Value,15} |");
                }
                writer.WriteLine(new string('-', 37));
            }
        }



        public static void WriteToExternalData(string fileName, Agency agency, string header)
        {

            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(header);
                writer.WriteLine($"{"Agentūros pavadinimas: "}{agency.Name}");
                writer.WriteLine($"{"Agentūros adresas: "}{agency.Adress}");
                writer.WriteLine($"{"Agentūros telefono numeris: "}{agency.PhoneNumber}");
                writer.WriteLine(new string('-', 191));
                writer.WriteLine($"| {"Miestas",15} | {"Rajonas",15} | {"Gatvė",15} |" +
                    $" {"Namo numeris",-15} | {"Tipas",-15} | {"Pastatymo metai",15} |" +
                    $" {"Plotas",15} | {"Kambarių skaičius",-20} | {"Šildymo tipas",20} | {"Aukštas",-15} |");
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

