using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Rectangle:Shape
	{
		double width;
		double height;

		public double Width
		{
			get => width;
			set => width = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}
		public double Height
		{
			get => height;
			set => height = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}

		public Rectangle(double with , double height, Color color) : base(color)
		{
			Width = with;
			Height = height;
		}
		public override double GetArea()
		{
			return Width * Height;
		}
		public override double GetPerimeter()
		{
			return (Width+Height) * 2;
		}
		public override void Draw(){}

		public override void Info()
		{
			Console.WriteLine($"Длины сторон: {width} / {height}");
			base.Info();
		}

	}
}
