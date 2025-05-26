using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Ellipse:Shape
	{
		double DiametrX { get; set; }
		double DiametrY { get; set; }

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
