using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Random random = new Random(0);
			Tree tree = new Tree();

			for (int i = 0; i < n; i++)
			{
				tree.Insert(random.Next(100));
			}
			tree.Print();
			Console.WriteLine();
			Console.WriteLine($"Минимальное значение {tree.MinValue()}");
			Console.WriteLine($"Максимальное значение {tree.MaxValue()}");
			Console.WriteLine($"Количество элементов {tree.Count()}");
			Console.WriteLine($"Сумма элементов {tree.Sum()}");

			Console.WriteLine($"\nВывод\n");
			tree.Print();
			Console.WriteLine();
			tree.Insert_For_Print_Dinamic();

			//tree.Erase(81);

			//Console.WriteLine($"\nПосле удаления 81");
			//tree.Print();
			//Console.WriteLine();
			//tree.Insert_For_Print_Dinamic();

			//Console.WriteLine($"количество уровней {tree.Depth_ALL}");

			//Console.WriteLine($"ширина слева: {tree.With_L}  ширина справа: {tree.With_R}");
			//tree.Insert_For_Print_Dinamic();

			//Console.WriteLine($"Удаляем");

			//tree.Clear();
			//tree.Print();
			//Console.WriteLine();
			//tree.Insert_For_Print_Dinamic();




		}
	}
}
