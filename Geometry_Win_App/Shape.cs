using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	abstract class Shape
	{
		int start_x;
		int start_y;
		int line_width;

		public int StartX
		{
			get => start_x;
			set => start_x = (value <  Constant_Display.MIN_START_X? Constant_Display.MIN_START_X : value > Constant_Display.MAX_START_X ? Constant_Display.MAX_START_X : value);
		}
		public int StartY
		{
			get => start_y;
			set => start_y = value < Constant_Display.MIN_START_Y ? Constant_Display.MIN_START_Y : value > Constant_Display.MAX_START_Y ? Constant_Display.MAX_START_Y : value;
		}
		public int LineWidth
		{
			get => line_width;
			set => line_width = value < Constant_Display.MIN_LINE_WIDTH ? Constant_Display.MIN_LINE_WIDTH : value > Constant_Display.MAX_LINE_WIDTH ? Constant_Display.MAX_LINE_WIDTH : value;
		}

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
