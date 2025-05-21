using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate:Student
	{
		public string Name_Diplom_Work { get; set; }
		public string Format_Diplom_Work { get; set; }
		public bool Сompleted_Diplom_Work { get; set; }

		public Graduate(Student student , string name_Diplom_Work , string format_Diplom_Work , bool completed_Diplom_Work = false):base(student)
		{
			Name_Diplom_Work = name_Diplom_Work;
			Format_Diplom_Work = format_Diplom_Work;
			Сompleted_Diplom_Work = completed_Diplom_Work;
		//	Console.WriteLine($"GConstructor\t:{this.GetHashCode()}");
		}

		~Graduate()
		{
		//	Console.WriteLine($"GDestructor\t:{this.GetHashCode()}");
		}

		public void Info()
		{
			base.Info();
			Console.WriteLine($"name work - {Name_Diplom_Work} ; format - {Format_Diplom_Work} ; completed status -  {Сompleted_Diplom_Work} ");
		}

	}
}
