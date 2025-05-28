using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Triangle:Shape
	{
		double side1;
		double side2;
		double side3;


		public double Side1
		{
			get => side1; 
			set => side1 = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}

		public double Side2
		{
			get => side2;
			set => side2 = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}

		public double Side3
		{
			get => side3;
			set => side3 = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}

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
			Console.WriteLine($"Тип углов: {type_of_triangle_angles()}");
			base.Info();
		}
		public string type_of_triangle_angles()
		{
			double cosA = (Side2 * Side2 + Side3 * Side3 - Side1 * Side1) / (2 * Side2 * Side3);
			double cosB = (Side1 * Side1 + Side3 * Side3 - Side2 * Side2) / (2 * Side1 * Side3);
			double cosC = (Side1 * Side1 + Side2 * Side2 - Side3 * Side3) / (2 * Side1 * Side2);

			if (cosA > 0 && cosB > 0 && cosC > 0)
				return "Остроугольный";
			if (cosA == 0 || cosB == 0 || cosC == 0)
				return "Прямоугольный";

			if (cosA < 0 || cosB < 0 || cosC < 0)
				return "Тупоугольный";

			return "Неопределен";
		}
	}
}
