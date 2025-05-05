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
        }
 
        protected void Upload_Click(object sender, EventArgs e)
        {
            int count = 0;
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/AgencyData"), "*.txt");
            Agency[] agencies = new Agency[filePaths.Count()];
            foreach (string path in filePaths)
            {
                Agency data = InOutUtils.ReadAgency(path);
                LoadDataToTable(data, form1, $"Duomenys iš failo {path}");
                agencies[count] = data;
                count++;
            }
            string mostCommonStreet = TaskUtils.FindMaxStreet(agencies);
            Dictionary<string, int> mostCommonStreetEstates = TaskUtils.PickOutObjectsByStreets(mostCommonStreet, agencies);
            LoadMostCommonStreet(mostCommonStreetEstates, form1);
            int minAge = TaskUtils.MinAgeForAll(agencies);
            Agency oldestEstates = TaskUtils.PickOutOldest(agencies, minAge);
            LoadDataToTable(oldestEstates, form1, "Seniausi objektai");
            Agency FusedAgencies = TaskUtils.FuseAgencies(agencies);
            Agency InAllAgencies = TaskUtils.FindInMultipleAgencies(FusedAgencies, agencies.Count());
            InAllAgencies.BubbleSort();
            LoadDataToTable(InAllAgencies, form1, "Objektai, kurie yra visose agentūrose");

        }
    }
}