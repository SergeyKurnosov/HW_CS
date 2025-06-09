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

			tree.TreePrint();
			tree.Balance();
			tree.TreePrint();




		}
	}
}
