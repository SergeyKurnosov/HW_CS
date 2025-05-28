using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class EquilateralTriangle:Triangle
	{
		public EquilateralTriangle(double side, Color color) : base(side, side, side, color) { }
	}
}
