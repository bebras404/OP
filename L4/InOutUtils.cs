using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Xml.Linq;

namespace L4
{
    public static class InOutUtils
    {
        public static Agency ReadAgency(string fileName)
        {
            Agency agency = new Agency();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string name = reader.ReadLine();
                string adress = reader.ReadLine();
                int phoneNumber = int.Parse(reader.ReadLine());
                agency = new Agency(name, adress, phoneNumber);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string city = values[0];
                    string district = values[1];
                    string street = values[2];
                    int houseNumber = int.Parse(values[3]);
                    string type = values[4];
                    DateTime buildDate = DateTime.Parse(values[5]);
                    double area = double.Parse(values[6]);
                    int numberOfRooms = int.Parse(values[7]);
                    var diff = values[8];
                    if (int.TryParse(diff, out int number))
                    {
                        RealEstate re = new Flat(city, district, street, houseNumber, type, buildDate, area, numberOfRooms, number);
                        agency.Add(re);
                    }
                    else
                    {
                        RealEstate re = new House(city, district, street, houseNumber, type, buildDate, area, numberOfRooms, diff);
                        agency.Add(re);
                    }
                    
                }

            }
            return agency;
        }

    }


}
