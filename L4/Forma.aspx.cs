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
            string folderPath = Server.MapPath("~/Files"); 
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dir.GetFiles("*.txt"))
            {
                string filePath = file.FullName;
                Agency agency = InOutUtils.ReadAgency(filePath);
                Session["Agency"]
            }



        }
    }
}