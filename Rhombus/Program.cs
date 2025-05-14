using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rhombus
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Console.Write("Введите размер фигуры: ");
			int n = Convert.ToInt32(Console.ReadLine());

			for(int i = 0; i < n*2; ++i)
			{
				int temp = i < n ? n - i - 1 : i - n;

				for (int j = 0; j < temp;)
				{
					Console.Write(" ");
					++j;
				}
					Console.Write(i < n ? "/" : "\\");

				temp = i < n ? i * 2 : (n*2) - 2 - (temp * 2);
				for (int j = 0; j < temp;)
				{
					Console.Write(" ");
					++j;
				}
				Console.Write(i < n ? "\\" : "/");
				Console.WriteLine();

			}


			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//for (int i = 0; i < n; i++)
			//{
			//	for (int j = i; j < n; j++) Console.Write(" "); Console.Write("/");
			//	for (int j = 0; j < i * 2; j++) Console.Write(" "); Console.Write("\\");
			//	Console.WriteLine();
			//}

			//for (int i = 0; i < n; i++)
			//{
			//	for (int j = 0; j <= i; j++) Console.Write(" "); Console.Write("\\");
			//	for (int j = 0; j < (n - i - 1) * 2; j++) Console.Write(" "); Console.Write("/");
			//	Console.WriteLine();
			//}

		}
	}
}
