using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Stack<int> myStack = new Stack<int>();
			myStack.Push(10);
			myStack.Push(20);
			myStack.Push(30);
			myStack.Push(40);
			myStack.Push(50);
			myStack.Push(60);
			Console.WriteLine($"Первы элемент стэка : {myStack.Peek()}"); 
			Console.WriteLine($"Удален элемент стэка : {myStack.Pop()}");
			Console.WriteLine($"Первы элемент стэка : {myStack.Peek()}");
		}
	}
}
