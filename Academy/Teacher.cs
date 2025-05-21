using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Teacher:Specialist
	{
		public string[] Names_groups { get; set; }
		public double Experience_teaching { get; set; }

		public Teacher(Specialist specialist , string[] names_groups , double experience_teaching):base(specialist)
		{
			Names_groups = names_groups;
			Experience_teaching = experience_teaching;
			//	Console.WriteLine($"TConstructor\t:{this.GetHashCode()}");
		}

		~Teacher()
		{
			//	Console.WriteLine($"TDestructor\t:{this.GetHashCode()}");
		}

		public void Info()
		{
			base.Info();
			Console.WriteLine("name groups:");
			for (int i = 0; i < Names_groups.Length; i++)
			{
				Console.WriteLine(Names_groups[i]);
			}
			Console.WriteLine($"experience teaching - {Experience_teaching} ");
		}



	}
}
