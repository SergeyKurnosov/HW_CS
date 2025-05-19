using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	internal class Point
	{

		public double X { get; set; }
		public double Y { get; set; }

		public Point(double x = 0, double y = 0)
		{
			X = x;
			Y = y;
			Console.WriteLine($"\nConstructor:\t{this.GetHashCode()}");
		}

		~Point()
		{
			Console.WriteLine($"\nDestructor:\t{this.GetHashCode()}");
		}

		public static Point operator +(Point left, Point right) 
		{return new Point(left.X + right.X, left.Y + right.Y);}

		public static double operator -(Point left, Point right) 
		{return Math.Sqrt(Math.Pow(right.X - left.X, 2) + Math.Pow(right.Y - left.Y, 2));}


		public override string ToString()
		{
			return $"x = {X} , y = {Y}";
		}

	}
}
