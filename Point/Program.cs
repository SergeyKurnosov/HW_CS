using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Point A = new Point();
			A.X = 20;
			A.Y = 30;
			Console.WriteLine(A);	

			Point B = new Point(50 , 10);
			Console.WriteLine(B);

			Console.WriteLine($"\nDistance : {A - B}");
		}
	}
}


