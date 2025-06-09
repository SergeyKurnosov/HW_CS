using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Queue<int> queue = new Queue<int>();
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			queue.Enqueue(4);
			queue.Enqueue(5);
			queue.Enqueue(6);

			Console.WriteLine($"Первый элемент очереди : {queue.Peek()}");

			Console.WriteLine($"Удален элемент очереди : {queue.Dequeue()}");
			Console.WriteLine($"Удален элемент очереди : {queue.Dequeue()}");

			Console.WriteLine($"Первый элемент очереди : {queue.Peek()}");

			Console.WriteLine($"Очередь пустая ? : {queue.IsEmpty()}");

		}
	}
}
