using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.Lists
{
	public class ProfClassesList
	{
		private List<Student> Classes;
		private string ClassName { get; set; }

		public ProfClassesList(string className, List<Student> afterFilter) 
		{
            Classes = afterFilter;
            this.ClassName = className;
        }




    }
}