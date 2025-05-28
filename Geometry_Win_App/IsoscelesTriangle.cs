using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class IsoscelesTriangle:Triangle
	{
		public IsoscelesTriangle(double side1, double side2, Color color) : base(side1, side1, side2, color) { }
	}
}
