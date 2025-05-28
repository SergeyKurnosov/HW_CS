using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Circle:Ellipse
	{
		public Circle(double radius , Color color):base(radius , radius , color) { }
	}
}
