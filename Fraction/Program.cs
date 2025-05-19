using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Fraction fraction1 = new Fraction(5 , 2) , fraction2 = new Fraction(30 , 40);

			fraction2.reduce();
			Console.WriteLine($"fraction1 - {fraction1}"); 
			Console.WriteLine($"fraction2 - {fraction2}");
			Console.WriteLine("\n---\n");

			Console.WriteLine($"fraction1 + fraction2 = {fraction1 + fraction2} -> {(fraction1 + fraction2).reduce()}");
			Console.WriteLine($"fraction1 - fraction2 = {fraction1 - fraction2} -> {(fraction1 - fraction2).reduce()}");
			Console.WriteLine($"fraction1 * fraction2 = {fraction1 * fraction2} -> {(fraction1 * fraction2).reduce()}");
			Console.WriteLine($"fraction1 / fraction2 = {fraction1 / fraction2} -> {(fraction1 / fraction2).reduce()}");

			Console.WriteLine($"fraction1 == fraction2 - {fraction1 == fraction2}");
			Console.WriteLine($"fraction1 != fraction2 - {fraction1 != fraction2}");
		}
	}
}
