using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
	internal class Stack<T>
	{
		private Node<T> top;

		public Stack()
		{
			top = null;
		}

		public void Push(T item)
		{
			Node<T> newNode = new Node<T>(item);
			newNode.Next = top;
			top = newNode;
		}

		public T Pop()
		{
			if (top == null)
				throw new InvalidOperationException("Стек пуст");

			T value = top.Data;
			top = top.Next;
			return value;
		}

		public T Peek()
		{
			if (top == null)
				throw new InvalidOperationException("Стек пуст");
			return top.Data;
		}

		public bool IsEmpty()
		{
			return top == null;
		}
	}
}
