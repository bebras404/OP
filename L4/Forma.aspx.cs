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
            foreach (string path in filePaths)
            {
                Agency[] agency = new Agency[filePaths.Count()];
                Agency data = InOutUtils.ReadAgency(path);
                LoadDataToTable(data, form1);
                agency[count] = data;
                count++;
            }
        }
    }
}