using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Ellipse:Shape
	{
		double diametrX;
		double diametrY;

		public double DiametrX
		{
			get => diametrX;
			set => diametrX = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}
		public double DiametrY
		{
			get => diametrY;
			set => diametrY = value < Constant_Display.MIN_SIZE ? Constant_Display.MIN_SIZE : value > Constant_Display.MAX_SIZE ? Constant_Display.MAX_SIZE : value;
		}

		public Ellipse(double diametrX, double diametrY, Color color) : base(color)
		{
		   DiametrX = diametrX;
		   DiametrY = diametrY;
		}
		public override double GetArea()
		{
			return Math.PI * (DiametrX/2) * (DiametrY/2);
		}
		public override double GetPerimeter()
		{
			return (Math.PI * 2) * Math.Sqrt((DiametrX * 2 + DiametrY * 2) / 8);
		}
		public override void Draw(){}

		public override void Info()
		{
			Console.WriteLine($"Длины осей: {DiametrY} / {DiametrX}");
			base.Info();
		}

	}
}
