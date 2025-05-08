using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte size_figure = input_size_figure();
			char symbol = '*';
			int height_figure = 0, width_figure = 0;

			if (size_figure == 0)
				size_figure = 2;

			height_figure = Convert.ToInt32(size_figure);
			width_figure = Convert.ToInt32(size_figure + (size_figure - 1));

			print_cube(height_figure, width_figure, symbol);
			print_triangle(height_figure, width_figure, symbol, 1);
			print_triangle(height_figure, width_figure, symbol, 2);
			print_triangle(height_figure, width_figure, symbol, 3);
			print_triangle(height_figure, width_figure, symbol, 4);
			print_rhombus(height_figure, width_figure);
			print_chessboard(height_figure, width_figure, symbol);
		}

		static byte input_size_figure()
		{
			byte size_figure = 0;
			do
			{

				Console.WriteLine("Please input size for figures ( 2 -> 254 )");
				size_figure = Convert.ToByte(Console.ReadLine());

			} while (size_figure < 2 || size_figure > 254);

			return size_figure;
		}


		static void print_cube(int height, int with, char s)
		{

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < with; j++)
				{
					if (j % 2 == 0)
						Console.Write(s);
					else Console.Write(' ');
				}
				Console.WriteLine();
			}

			Console.WriteLine();
		}


		static void print_triangle(int height, int with, char s, byte num)
		{

			int position = 0, plus_minus = 0;
			switch (num)
			{
				case 1:
					position = 1;
					plus_minus = 2;
					break;
				case 2:
					position = with;
					plus_minus = -2;
					break;
				case 3:
					position = 0;
					plus_minus = 2;
					break;
				case 4:
					position = with - 1;
					plus_minus = -2;
					break;
			}

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < with; j++)
				{

					switch (num)
					{
						case 1:
						case 2:
							if (j <= position)
							{
								if (j % 2 == 0)
									Console.Write(s);
								else Console.Write(' ');
							}
							break;
						case 3:
						case 4:
							if (j >= position)
							{
								if (j % 2 == 0)
									Console.Write(s);
								else Console.Write(' ');
							}
							else
							{
								Console.Write(' ');
							}
							break;
					}

				}
				Console.WriteLine();
				position += plus_minus;
			}
			Console.WriteLine();
		}

		static void print_rhombus(int height, int with)
		{
			++with;

			height *= 2;

			char left = '/', right = '\\';
			int middle = with / 2, space = 0;

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < with; j++)
				{
					if (i < height / 2)
					{

						if (j == (middle - space) - 1)
							Console.Write(left);
						else if (j == middle + space)
							Console.Write(right);
						else Console.Write(' ');

					}
					else
					{
						if (j == (middle - space) - 1)
							Console.Write(right);
						else if (j == middle + space)
							Console.Write(left);
						else Console.Write(' ');
					}

				}

				if (i < (height / 2) - 1)
					++space;
				else if (i >= height / 2)
					--space;
				Console.WriteLine();
			}

			Console.WriteLine();
		}


		static void print_chessboard(int height, int with, char s)
		{

			bool selector = true;

			for (int i = 0; i < height * 8; i++)
			{

				if (i % height == 0)
					selector = !selector ? true : false;

				for (int j = 0; j < 4; j++)
				{
					if (!selector)
					{
						for (int pm = 0; pm < with; pm++)
							Console.Write(' ');
					}

					for (int c = 0; c < with; c++)
					{
						if (c % 2 == 0)
							Console.Write(s);
						else Console.Write(' ');
					}


					if (selector)
					{
						for (int pm = 0; pm < with; pm++)
							Console.Write(' ');
					}

				}
				Console.WriteLine();
			}

			Console.WriteLine();
		}

	}
}
