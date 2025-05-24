using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD5
{
	public partial class Forma : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/AppData/");
            string[] filePaths = Directory.GetFiles(folderPath, "*.txt");
            List<ClassList<StudentClasses>> studentsChoises = filePaths.Select(path => InOut.ReadStudents(path)).ToList();
            ClassList<ProfClasses> professors = InOut.ReadProfessors(Server.MapPath("~/ProfData.txt"));
            studentsChoises.ForEach(students =>
            {
                LoadDataToTable(students, $"Fakultetas: {students.GetFaculty()}", PH1);
            });
            LoadDataToTable(professors, "Profesoriai", PH2);





        }
    }
}