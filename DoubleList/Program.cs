using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DoubleList list2 = new DoubleList() { 3, 5, 8, 13, 21 };

			foreach (int i in list2)
			{
				Console.Write($"{i}\t");
			}
			Console.WriteLine();


			///////////////////////////////////////////////////////

			//Console.WriteLine($"\nВведите размер списка : ");
			//int n = Convert.ToInt32(Console.ReadLine());

			//Random rand = new Random(0);


			//DoubleList list = new DoubleList();
			//list.PushFront(123);
			//list.PopBack();
			//for (int i = 0; i < n; i++)
			//{
			//	list.PushBack(rand.Next(100));
			//}
			//list.Print_go();


			//bool inputError;
			//do
			//{
			//	inputError = false;
			//	Console.Write("Введите индекс: ");
			//	int index = Convert.ToInt32(Console.ReadLine());
			//	Console.Write("Введите значение: ");
			//	int value = Convert.ToInt32(Console.ReadLine());
			//	try
			//	{
			//		list.Insert(value, index);
			//	}
			//	catch (Exception ex)
			//	{

			//		Console.WriteLine(ex.Message);
			//		inputError = true;
			//	}
			//} while (inputError);
			//list.Print_go();
		}
	}
}
