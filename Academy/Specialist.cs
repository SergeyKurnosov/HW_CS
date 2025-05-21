using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Specialist:Human
	{
		public string Speciality { get; set; }
		public double Experience_work { get; set; }
		public Specialist
			(
				string lastName, string firstName, int age,
				string speciality, double experience
			) : base(lastName, firstName, age)
		{
			Speciality = speciality;
			Experience_work = experience;
		//	Console.WriteLine($"SConstructor: {this.GetHashCode()}");
		}

		public Specialist(Human human, string speciality, double experience): base(human)
		{
			Speciality = speciality;
			Experience_work = experience;
			//	Console.WriteLine($"SConstructor: {this.GetHashCode()}");
		}

		public Specialist(Specialist other): base(other.LastName , other.FirstName , other.Age)
		{
			Speciality = other.Speciality;
			Experience_work = other.Experience_work;
			//	Console.WriteLine($"SCopyConstructor: {this.GetHashCode()}");
		}

		~Specialist()
		{
		//	Console.WriteLine($"SDestructor: {this.GetHashCode()}");
		}

		public void Info()
		{
			base.Info();
			Console.WriteLine($"speciality - {Speciality} , experience work by speciality {Experience_work}");
		}
	}
}
