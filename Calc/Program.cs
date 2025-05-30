using Calc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	class MyException : Exception
	{
		public MyException() : base("Is MyException") { }
		public MyException(string msg) : base(msg) { }
	}

	class MyNewException : MyException
	{
		public MyNewException(string msg) : base(msg) { }
	}
}

	internal class Program
	{

	static void ThrowsMethod()
	{
		try
		{
			throw new MyNewException("o-o-oops");
		}
		catch (MyException)
		{
			throw;
		}
	}

	static void Main()
	{
		try
		{
			ThrowsMethod();
			Console.WriteLine("Hello world!");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		//static void Main(string[] args)
		//{

		//	Human h = new Employee("java programmer", "software development");

		//	Console.WriteLine(
		//	"age: {0} name: {1} position: {2} department: {3}",
		//	 h.Age, h.Name, h.Position, h.Department);

		//}


	}
}
