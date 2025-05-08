using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_Game
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("---=== Hello Gamer ( please wait 5 seconds ) ===---");
			Console.WriteLine("To move use arrows or WASD, to exit use ESCAPE");

			Thread.Sleep(5000);

			int left_ = Console.WindowWidth / 2, 
				top_ = Console.WindowHeight / 2, 
				window_height = 0, 
				window_width = 0;

			char cursor_ = '*';

			Console.CursorVisible = false;

			ConsoleKey key;

			do
			{
				Console.Clear();
				Console.SetCursorPosition(left_, top_);
				Console.Write(cursor_);

				window_height = Console.WindowHeight;
				window_width = Console.WindowWidth;

				key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						if (top_ < window_height-1)
						{
							++top_;
							Console.SetCursorPosition(left_, top_);
						}
						break;
					case ConsoleKey.W:
					case ConsoleKey.UpArrow:
						if (top_ > 0)
						{
							--top_;
							Console.SetCursorPosition(left_, top_);
						}
						break;
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						if (left_ > 0)
						{
							--left_;
							Console.SetCursorPosition(left_, top_);
						}
						break;
					case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						if (left_ < window_width-1)
						{
							++left_;
							Console.SetCursorPosition(left_, top_);
						}
						break;
				}
			} while (key != ConsoleKey.Escape);
		}
	}
}
