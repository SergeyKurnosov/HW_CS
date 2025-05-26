using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	abstract class Shape
	{
		public Color Color { get; set; }
		public Shape(Color color)
		{
			Color = color;
		}
		public abstract double GetArea();
		public abstract double GetPerimeter();
		public abstract void Draw();
		public virtual void Info()
		{
			Console.WriteLine($"Площадь фигуры: {GetArea()}");
			Console.WriteLine($"Периметр фигуры:{GetPerimeter()}");
			Console.WriteLine("\n---\n");
			Draw();
		}
	}
}
