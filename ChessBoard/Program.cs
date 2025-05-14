using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Console.Write("Введите размер фигуры: ");
			int n = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < n * 8; i++)
			{

				char s1 = ' ', s2 = ' ';
				if ((i >= 0 && i < n) || (i >= n * 2 * (i / (n * 2)) && i < n * 2 * (i / (n * 2)) + n))
					s1 = '*';
				else
					s2 = '*';

				for (int j = 0; j < 4; j++)
				{

					for (int k = 0; k < n; k++)
						Console.Write($"{s1,2}");

					for (int k = 0; k < n; k++)
						Console.Write($"{s2,2}");

				}

				Console.WriteLine();


			}

		}
	}
}
