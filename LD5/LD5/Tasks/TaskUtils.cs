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

        public static List<StudByProfList> TakeClassesByName(List<Professor> profs, List<StudList> studentsLists)
        {
            return profs.Select(prof =>
                new StudByProfList(
                    prof.FirstName,
                    prof.LastName,
                    prof.ClassName,
                    studentsLists.SelectMany(sl => sl.GetStudentsByClass(prof.ClassName)).ToList()
                )
            );

        }

        public static List<Professor> FilterProfessorsByName(string Name_LastName, List<Professor> profesors)
        {
          return profesors
                .Where(p => (p.FirstName + " " + p.LastName).Equals(Name_LastName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }








    }
}