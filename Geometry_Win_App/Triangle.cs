using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Triangle:Shape
	{
		double Side1 { get; set; }
		double Side2 { get; set; }
		double Side3 { get; set; }

		public Triangle(double side1, double side2, double side3, Color color) : base(color)
		{
			Side1 = side1;
			Side2 = side2;
			Side3 = side3;
		}
		public override double GetArea()
		{
			double p = GetPerimeter() / 2;
			return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
		}
		public override double GetPerimeter()
		{
			return Side1+Side2+Side3;
		}
		public override void Draw() { }

		public override void Info()
		{
			Console.WriteLine($"Длины сторон: {Side1} / {Side2} / {Side3}");
			base.Info();
		}
	}
}
