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
        /// <summary>
        /// Calculates the workload for each professor.
        /// Workload = total students in all classes * total credits.
        /// </summary>
        /// <param name="profClasses">List of professors with their classes.</param>
        /// <param name="choises">List of student lists (choices).</param>
        /// <returns>List of professor workloads.</returns>
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

        /// <summary>
        /// Gets a list of classes for each professor with students in those classes.
        /// </summary>
        /// <param name="profs">List of professors.</param>
        /// <param name="studentsLists">List of student lists.</param>
        /// <returns>List of professor classes with students.</returns>
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

        /// <summary>
        /// Finds professors by full name (FirstName LastName).
        /// Shows alert if input is wrong.
        /// </summary>
        /// <param name="Name_LastName">Professor's full name (FirstName LastName).</param>
        /// <param name="profesors">List of professors.</param>
        /// <returns>List of professors matching the name.</returns>
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