using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Program
	{
		static readonly string delimiter = "\n----------------------------------------------\n";
		static void Main(string[] args)
		{

			Student student1 = new Student(new Human("student1_lastName", "student1_firstName", 20), "Chemistry", "WW_220", 95, 96);
			Student student2 = new Student(new Human("student2_lastName", "student2_firstName", 25), "Chemistry", "WW_221", 94, 97);
			Student student3 = new Student(new Human("student3_lastName", "student3_firstName", 30), "Math", "WM_30", 93, 98);
			Student student4 = new Student(new Human("student4_lastName", "student4_firstName", 35), "Math", "WM_55", 92, 99);
			Student student5 = new Student(new Human("student5_lastName", "student5_firstName", 40), "IT", "WI_29", 91, 100);

			Graduate graduate1 = new Graduate(student4, "Geometry", "presentation");
			Graduate graduate2 = new Graduate(student5, "Calculator", "programm" , true);

			Console.WriteLine("\nStudents:\n");
			Console.WriteLine(delimiter);
			student1.Info();
			Console.WriteLine(delimiter);
			student2.Info();
			Console.WriteLine(delimiter);
			student3.Info();
			Console.WriteLine(delimiter);

			Console.WriteLine("\nGraduates:\n");
			Console.WriteLine(delimiter);
			graduate1.Info();
			Console.WriteLine(delimiter);
			graduate2.Info();
			Console.WriteLine(delimiter);

			Specialist specialist1 = new Specialist(new Human("specialist1_lastName", "specialist1_firstName", 40), "IT" , 15);
			Specialist specialist2 = new Specialist(new Human("specialist2_lastName", "specialist2_firstName", 45), "Math", 20);
			Specialist specialist3 = new Specialist(new Human("specialist3_lastName", "specialist3_firstName", 50), "Chemistry", 25);
			Specialist specialist4 = new Specialist(new Human("specialist4_lastName", "specialist4_firstName", 55), "Chemistry", 30);
			Specialist specialist5 = new Specialist(new Human("specialist5_lastName", "specialist5_firstName", 60), "Chemistry", 35);

			Teacher teacher1 = new Teacher(specialist3 , new string[]{ "WW_220", "WW_221", "WW_222",} , 10);
			Teacher teacher2 = new Teacher(specialist1, new string[] { "WI_28", "WI_29" }, 5);

			Console.WriteLine("\nSpecialists:\n");
			Console.WriteLine(delimiter);
			specialist2.Info();
			Console.WriteLine(delimiter);
			specialist4.Info();
			Console.WriteLine(delimiter);
			specialist5.Info();
			Console.WriteLine(delimiter);

			Console.WriteLine("\nTeachers:\n");
			Console.WriteLine(delimiter);
			teacher1.Info();
			Console.WriteLine(delimiter);
			teacher2.Info();
			Console.WriteLine(delimiter);




		}
	}
}
