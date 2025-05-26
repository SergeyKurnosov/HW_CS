using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Rectangle:Shape
	{
		double Side1 { get; set; }
		double Side2 { get; set; }

		public Rectangle(double side1 , double side2, Color color) : base(color)
		{
			Side1 = side1;
			Side2 = side2;
		}
		public override double GetArea()
		{
			return Side1 * Side2;
		}
		public override double GetPerimeter()
		{
			return (Side1+Side2) * 2;
		}
		public override void Draw(){}

		public override void Info()
		{
			Console.WriteLine($"Длины сторон: {Side1} / {Side2}");
			base.Info();
		}

	}
}
