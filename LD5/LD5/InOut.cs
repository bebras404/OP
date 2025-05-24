using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LD5
{
	public static class InOut
	{
		public static ClassList<StudentClasses>ReadStudents(string fileName)
		{
			ClassList<StudentClasses> students = null;
			using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8)) 
			{
				string line;
				int lineCounter = 1;
                line = reader.ReadLine();
                students = new ClassList<StudentClasses>(line);
				while ((line = reader.ReadLine()) != null) 
				{
					try
					{
						string[] parts = line.Split(';');
						StudentClasses student = new StudentClasses(parts[0], parts[1], parts[2], parts[3]);
                        students.AddClass(student);
                    }
					catch 
					{
                        HttpContext.Current.Response.Write(
							String.Format($"<script>alert('Klaida failo" +
							$" {fileName} eilutėje {lineCounter}')</script>")); 
						continue;
                    }
					finally { lineCounter++; }
                }                
            }
            return students;
        }

		public static ClassList<ProfClasses> ReadProfessors(string fileName) 
		{
			ClassList<ProfClasses> profs = null;
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;
                int lineCounter = 1;
                profs = new ClassList<ProfClasses>();
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        string[] parts = line.Split(';');
                        ProfClasses professor = new ProfClasses(parts[0], parts[1], parts[2], int.Parse(parts[3]));
                        profs.AddClass(professor);
                    }
                    catch
                    {
                        HttpContext.Current.Response.Write(
                            String.Format($"<script>alert('Klaida failo" +
                            $" {fileName} eilutėje {lineCounter}')</script>"));
                        continue;
                    }
                    finally { lineCounter++; }
                }
            }
            return profs;

        }




    }
}