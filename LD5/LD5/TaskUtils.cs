using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
	public static class TaskUtils
	{
		public static int CountStudents(string ClassName, ClassList<StudentClasses> studentChoises) 
		{
			return studentChoises.Where(s => s.ClassName == ClassName).Count();
        }

		public static ClassList<ProfClasses> CalculateLoad(ClassList<ProfClasses> proClasses, ClassList<StudentClasses> choises) 
		{
			ClassList<ProfClasses> singleListLoad = new ClassList<ProfClasses>();
			singleListLoad = proClasses.Select(s => new ProfClasses(s.ClassName, s.LastName, s.FirstName, (CountStudents(s.ClassName, choises)*s.CreditCount))).ToList();
			return singleListLoad;
		}


	}
}