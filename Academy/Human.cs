﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Human
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }
		public Human(string lastName, string firstName, int age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
		//	Console.WriteLine($"HConstructor:\t{this.GetHashCode()}");
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;

		//	Console.WriteLine($"HCopyConstructor:\t{this.GetHashCode()}");
		}
		~Human()
		{
		//	Console.WriteLine($"HDestructor:\t{this.GetHashCode()}");
		}
		public void Info()
		{
			Console.WriteLine($"last name - {LastName} ; first name - {FirstName} ; age - {Age}");
		}
	}
}
