using LD5.Lists;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD5
{
    public static class TaskUtils
    {
        public static List<ProfWorkLoad> CalculateLoad(List<Professor> profClasses, List<StudList> choises)
        {
            return profClasses
                .GroupBy(prof => new { prof.LastName, prof.FirstName })
                .Select(profGroup =>
                {
                    int totalStudents = profGroup.Sum(prof =>
                        choises.Sum(cl => cl.CountStudents(prof.ClassName))
                    );
                    int totalCredits = profGroup.Sum(prof => prof.CreditCount);
                    int load = totalStudents * totalCredits;
                    return new ProfWorkLoad(profGroup.Key.LastName, profGroup.Key.FirstName, load);
                })
                .ToList();
        }

        public static List<ProfClassesList> TakeClassesByName(List<Professor> profs, List<StudList> studentsLists)
        {
            List<ProfClassesList> tempList = profs
            .Select(prof => new ProfClassesList(
            prof.ClassName,
            studentsLists.SelectMany(s => s.GetStudentsByClass(prof.ClassName)).OrderBy(s => s.Group).ThenBy(s => s.LastName).ToList(),
            prof.FirstName,
            prof.LastName)).ToList();

            return tempList;

        }

        public static List<Professor> FilterProfessorsByName(string Name_LastName, List<Professor> profesors)
        {   
            List<Professor> filteredProfessors = new List<Professor>();
            try
            {
                string[] parts = Name_LastName.Split(' ');
                string name = parts[0];
                string lastName = parts[1];
                filteredProfessors = profesors
                    .Where(prof => prof.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                                   prof.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            }
            catch
            {
                HttpContext.Current.Response.Write(
                   String.Format($"<script>alert('Neteisingai įvestas dėstytojas" +
                  $" {Name_LastName}. Formatas: Vardas Pavardė')</script>"));
            }
            return filteredProfessors;

        }








    }
}