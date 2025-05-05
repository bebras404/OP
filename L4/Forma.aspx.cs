using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L4
{
    public partial class Forma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("~/ExternalData.txt"))) { File.Delete(Server.MapPath("~/ExternalData.txt")); }
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            string[] filePaths;
            string folderPath = "~/AgencyData";
            int count = 0;

            try
            {
                filePaths = Directory.GetFiles(Server.MapPath(folderPath), "*.txt");
            }
            catch
            {
                MessageBox(this, $"Nepavyko gauti failų iš aplanko: {folderPath}");
                return;
            }

            Agency[] agencies = new Agency[filePaths.Length];
            Agency data = null;

            foreach (string path in filePaths)
            {
                try
                {
                    data = InOutUtils.ReadAgency(path);
                }
                catch (Exception ex)
                {
                    MessageBox(this, $"Klaida: " + ex.Message);
                    continue;
                }

                try
                {
                    LoadDataToTable(data, form1, $"Duomenys iš failo: {Path.GetFileName(path)}");
                    
                }
                catch (Exception)
                {
                    MessageBox(this, $"Nepavyko atvaizduoti duomenų iš failo:\n{Path.GetFileName(path)}");
                    
                }

                agencies[count] = data;
                count++;

                try
                {
                    InOutUtils.WriteToExternalData(Server.MapPath("~/ExternalData.txt"), data, "Nuskaityti duomenys:");
                }
                catch (Exception)
                {
                    MessageBox(this, $"Nepavyko įrašyti duomenų iš failo:\n{Path.GetFileName(path)} į išorinį failą.");
                    continue;
                }
            }

            Dictionary<string, int> mostCommonStreetEstates = TaskUtils.PutToDicti(agencies);
            int MaxCount = TaskUtils.FindMaxStreetCount(mostCommonStreetEstates);
            mostCommonStreetEstates = TaskUtils.PickOutCommonStreets(mostCommonStreetEstates, MaxCount);
            LoadMostCommonStreet(mostCommonStreetEstates, form1);
            InOutUtils.WriteToExternalDataDics(Server.MapPath("~/ExternalData.txt"), mostCommonStreetEstates, "Dažniausiai pasikartojančios gatvės: ");

            int minAge = TaskUtils.MinAgeForAll(agencies);
            Agency oldestEstates = TaskUtils.PickOutOldest(agencies, minAge);
            LoadDataToTable(oldestEstates, form1, "Seniausi objektai");
            InOutUtils.WriteToExternalData(Server.MapPath("~/ExternalData.txt"), oldestEstates, "Seniausi objektai: ");

            Agency FusedAgencies = TaskUtils.FuseAgencies(agencies);
            Agency InAllAgencies = TaskUtils.FindInMultipleAgencies(FusedAgencies);
            InAllAgencies.BubbleSort();
            LoadDataToTable(InAllAgencies, form1, "Objektai kurie yra daugiau nei vienoje agentūroje");
            InOutUtils.WriteToExternalData(Server.MapPath("~/ExternalData.txt"), InAllAgencies, "Objektai kurie yra daugiau nei vienoje agentūroje: ");
            InOutUtils.WriteToCSV(InAllAgencies, Server.MapPath("~/AgencyData/Kartojasi.csv"), "Objektai kurie yra daugiau nei vienoje agentūroje");

            Agency Large = TaskUtils.LargeObjs(agencies);
            Large.BubbleSort();
            LoadDataToTable(Large, form1, "Dideli objektai");
            InOutUtils.WriteToCSV(Large, Server.MapPath("~/AgencyData/Dideli.csv"), "Dideli objektai");
            InOutUtils.WriteToExternalData(Server.MapPath("~/ExternalData.txt"), Large, "Dideli objektai: ");
        }
    }
}   
